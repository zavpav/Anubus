import { HttpClient } from '@angular/common/http';
import { AfterViewInit, Component, ElementRef, Input, OnInit, ViewChild, ViewChildren } from '@angular/core';
import { DxFormComponent } from 'devextreme-angular';
import { Item, SimpleItem } from 'devextreme/ui/form';
import { MetaInformation, MetaInformationService } from 'src/app/shared/domain-info/MetaInformation';

import { environment } from 'src/environments/environment';
import { SprBaseEntity } from './spr-base-entity';

@Component({
  selector: 'app-spr-base-edit',
  templateUrl: './spr-base-edit.component.html',
  styles: [
  ]
})
export class SprBaseEditComponent implements OnInit, AfterViewInit {

  @Input()
  entityId?: number

  @Input()
  endpoint!: string

  @Input()
  isTree?: boolean

  @ViewChild("sprForm") dxForm!: DxFormComponent

  entity?: SprBaseEntity
  meta?: MetaInformation[];
  isLoaded: boolean = false;
  isValid: boolean = false

  constructor(private http: HttpClient,
    private metaInformationService: MetaInformationService
  ) {
    this.isTree = false
  }

  ngOnInit(): void {
  }

  ngAfterViewInit(): void {
    this.http.get(environment.mainEndpoint + this.endpoint, { params: { withMeta: true, id: this.entityId ?? -1 } })
      .subscribe((x: any) => {
        console.log(x)
        this.meta = Object.values(x.meta)[0] as MetaInformation[]
        this.entity = x.entity
        this.fillEditForm();
        this.isLoaded = true
      })
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
  }

  cancelButton(): void {
    console.log("Отмена")
  }

}
