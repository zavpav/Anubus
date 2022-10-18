import { HttpClient, HttpHeaders } from '@angular/common/http';
import { AfterViewInit, Component, ElementRef, Input, OnDestroy, OnInit, ViewChild, ViewChildren } from '@angular/core';
import { DxFormComponent } from 'devextreme-angular';
import { Item, SimpleItem } from 'devextreme/ui/form';
import { filter, Observable } from 'rxjs';
import { ServerNotifierService } from 'src/app/services/server-notifier.service';
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
    throw new Error('Method not implemented.');
  }

  fillEditForm() {
    let o = this.dxForm.instance.option();

    this.dxForm.instance.option('formData', this.entity)
    const items: Item[] = []
    for (let inf of this.meta!.filter(x => !x.dataField.endsWith("id") && !x.dataField.endsWith("Id"))) {
      const editorItem = this.metaInformationService.generateSimpleItemByMetaInformation(inf)
      items.push(editorItem)
    }

    this.dxForm.instance.option("items", items)

    const validate = this.dxForm.instance.validate()
    this.isValid = validate.isValid ?? false
  }

  onFieldDataChanged($event: any) {
    if (!this.isLoaded) {
      return;
    }
    const validate = this.dxForm.instance.validate()
    this.isValid = validate.isValid ?? false;
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

        // Обновления notify
        this.serverNotifierService.notifies$
          .pipe(filter(flt => flt.executionId === saveRes.executionId))
          .subscribe(n => {
            console.log('updateEditFormBySignalR', n)
            if (n.message) {
              this.loadingMessage = n.message
            }
            if (n.isFinished) {
              this.isSaving = false
            }
          })

        // Подписка на ошибки?

      })
    //    setTimeout(() => { this.isSaving = false }, 10000)
  }

  cancelButton(): void {
    console.log("Отмена")
  }

}
