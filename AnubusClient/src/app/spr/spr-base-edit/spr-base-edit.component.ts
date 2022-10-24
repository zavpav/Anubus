import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component, Input, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { DxFormComponent } from 'devextreme-angular';
import { Item, SimpleItem } from 'devextreme/ui/form';
import { ValidationCallbackData } from 'devextreme/ui/validation_rules';
import { filter, Observable, Subscription, timeInterval } from 'rxjs';
import { LongOperationUpdate, ServerNotifierService } from 'src/app/services/server-notifier.service';
import { MetaInformation, MetaInformationService } from 'src/app/shared/domain-info/MetaInformation';

import { environment } from 'src/environments/environment';
import { SprBaseEntity } from './spr-base-entity';

@Component({
  selector: 'app-spr-base-edit',
  templateUrl: './spr-base-edit.component.html',
  styles: [
  ]
})
export class SprBaseEditComponent implements OnInit, OnDestroy {

  @Input()
  entityId?: number

  @Input()
  endpoint!: string

  @Input()
  isTree?: boolean

  @ViewChild("sprForm") dxForm!: DxFormComponent

  entity?: SprBaseEntity
  meta?: MetaInformation[]
  isLoaded: boolean = false
  isValid: boolean = false
  isSaving: boolean = false
  loadingMessage: string = ""

  // Подписка на обновления операций (не забывать отписываться)
  notifySubscription?: Subscription

  // Серверные ошибки при сохранении данных
  serverErrors?: string[];
  //  notify$: Observable<string>

  constructor(private http: HttpClient,
    private metaInformationService: MetaInformationService,
    private serverNotifierService: ServerNotifierService
  ) {
    this.isTree = false
    //    this.notify$ = serverNotifierService.
  }

  ngOnInit(): void {
    this.loadingMessage = "Загрузка"
    this.http.get(environment.mainEndpoint + this.endpoint, { params: { withMeta: true, id: this.entityId ?? -1 } })
      .subscribe((x: any) => {
        console.log(x)
        this.meta = Object.values(x.meta)[0] as MetaInformation[]
        this.entity = x.entity
        this.fillEditForm();
        this.isLoaded = true
      })
  }

  ngOnDestroy(): void {
    if (this.notifySubscription) {
      this.notifySubscription.unsubscribe();
      this.notifySubscription = undefined;
    }

    throw new Error('Method not implemented.');
  }

  fillEditForm() {
    let o = this.dxForm.instance.option();

    this.dxForm.instance.option('formData', this.entity)
    const items: Item[] = []
    for (let inf of this.meta!.filter(x => !x.dataField.endsWith("id") && !x.dataField.endsWith("Id"))) {
      const editorItem = this.metaInformationService.generateSimpleItemByMetaInformation(inf)

      if (editorItem.dataField == 'code') {
        editorItem.validationRules?.push({
          type: 'async',
          ignoreEmptyValue: true,
          message: 'Код должен быть уникален',
          reevaluate: false,
          validationCallback: this.validateSprCode.bind(this)
        })
      }


      items.push(editorItem)
    }

    this.dxForm.instance.option("items", items)

    const validate = this.dxForm.instance.validate()
    validate.complete?.then(res => this.isValid = res.isValid ?? false)
    //this.isValid = validate.isValid ?? false
  }

  // Асинхронная проверка уникальности кода
  private validateSprCode(options: ValidationCallbackData): Promise<any> {
    let self = this
    return new Promise<any>((resolve, reject) => {
      if (options.formItem.dataField != 'code') {
        reject("Нельзя применять правило не для поля 'code'")
      }

      this.http
        .get<string>(environment.mainEndpoint + self.endpoint + "/ValidateUniqueCode", { params: { code: options.value } })
        .subscribe({
          next: (res: any) => {

            if (!res || !res.message) {
              resolve("")
            }

            if (res.message == null || res.message == "") {
              resolve("")
            } else {
              reject(res.message)
            }
          },
          error:
            (err: any) => {
              reject(err.message)
            }
        }
        )
    })
  }



  onFieldDataChanged($event: any) {
    if (!this.isLoaded) {
      return;
    }
    this.revalidate()
  }

  revalidate() {
    const validate = this.dxForm.instance.validate()
    this.isValid = !!validate && validate.status != 'pending' && validate.isValid === true;
    validate.complete?.then(res => {
      this.isValid = res.isValid === true
    }
    )
  }

  okButton(): void {
    console.log("Сохранение")
    this.isSaving = true
    this.loadingMessage = "Сохранение"

    const headers = new HttpHeaders({
      'Content-Type': 'application/json',
    });

    this.http.post(environment.mainEndpoint + this.endpoint, this.entity, { headers: headers })
      .subscribe((saveRes: any) => {
        console.log('saveInfo', saveRes)

        // Включаем обработку нотификацию сервера
        this.serverErrors = undefined;
        if (this.notifySubscription) {
          console.error("Ошибка настройки получения уведомления. На момент подписки уже что-то есть.")
        }
        // Обновления notify
        this.notifySubscription = this.serverNotifierService.notifies$
          .pipe(filter(flt => flt.executionId === saveRes.executionId))
          .subscribe(serverNotification => this.longOperationNotify(serverNotification))
      })
  }

  // Обработка нотификации сервера
  private longOperationNotify(serverNotification: LongOperationUpdate): void {
    console.log('updateEditFormBySignalR', serverNotification)
    if (serverNotification.message) {
      this.loadingMessage = serverNotification.message
      if (!!serverNotification.domainErrors) {
        console.error("С сервера пришли ошибки, но операция не закончена")
      }
    }
    if (serverNotification.isFinished) {
      this.isSaving = false
      if (serverNotification.domainErrors) {
        const items = this.dxForm.instance.option("items") as SimpleItem[] // не совсем корректно, но пока так
        const errList: string[] = []
        for (const serverErr in serverNotification.domainErrors) {
          const fldErrs = serverNotification.domainErrors[serverErr]
          let fldName = serverErr
          const flds = items.filter(x => x.dataField == serverErr)
          if (items.length > 0) {
            fldName = flds[0]?.label?.text ?? serverErr
          }

          for (const err of fldErrs) {
            errList.push(`Поле '${fldName}' содержит ошибку "${err}"`)
          }
        }
        this.serverErrors = errList

        // if (!items) {
        //   throw new Error("Нет элементов")
        // }
        // for (let itm of items) {
        //   if (!itm.dataField) {
        //     continue // Отсекаем что может попасть не так плюс пока группы не учитываем.
        //   }

        //   var newErr = n.domainErrors[itm.dataField ?? ""]
        //   if (!!newErr) {
        //     if (!itm.validationRules) {
        //       itm.validationRules = []
        //     }
        //     for (let err of newErr) {
        //       itm.validationRules.push({ type: "custom", message: err, validationCallback: (options: ValidationCallbackData) => false })
        //       itm.validationRules.push({ type: "custom", message: err, validationCallback: (options: ValidationCallbackData) => true })
        //     }
        //   }
        // }

      }
      this.dxForm.instance.validate()

      if (this.notifySubscription) {
        this.notifySubscription.unsubscribe();
        this.notifySubscription = undefined;
      }
    }
  }

  cancelButton(): void {
    console.log("Отмена")
  }

}
