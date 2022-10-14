import { Component, Input, OnInit } from '@angular/core';
import CustomStore from 'devextreme/data/custom_store';
import { IDomainListService } from 'src/app/services/domain-list-service-base.service';
import { ColumnInfo } from '../../domain-info/ColumnInfo';


// Внутреннее описание действия
interface InternalActionInfo {
  trackBy: string
  id: string
  objId: string
  glyph: string
  tooltip: string
  isServerSide: boolean
  href?: string
}


@Component({
  selector: 'app-domain-tree',
  templateUrl: './domain-tree.component.html',
  styles: [
  ]
})
export class DomainTreeComponent implements OnInit {
  // Вспомогательный класс преобразования данных для работы с сервером
  @Input()
  gridService?: IDomainListService

  //Заполненные данные методами devextreme
  dataSource!: CustomStore<any, any>

  // Набор отображаемых колонок
  showedColumns?: ColumnInfo[];

  constructor() { }

  ngOnInit(): void {
    if (!this.gridService) {
      throw new Error("domainGridServices не инициализирован")
    }

    this.gridService.getListColumnsInfo()
      .subscribe(columnInfos => {
        columnInfos = [{ dataField: "actions", caption: "Действия" }, ...columnInfos]
        this.showedColumns = columnInfos.filter(x => !x.dataField.endsWith("id") && !x.dataField.endsWith("Id"))
        this.dataSource = this.gridService!.createListDataStore()
      })

  }

  // Проверка на то что доступны "визуальные операции" типа сортировки, фильтров и т.д. и тп.
  // Для "действий" это запрещено.
  allowVisualOperation(c: ColumnInfo) {
    return c.dataField !== "actions";
  }

  // Функция трекинга генерации трекинга операций 
  trackByFn(index: number, actionInfo: InternalActionInfo): string {
    return actionInfo.trackBy
  }

}
