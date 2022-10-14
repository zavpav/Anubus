/*
  Базовый класс отображения доменных объектов в виде списка
*/

import { Component, Input, OnInit } from '@angular/core';

import CustomStore from 'devextreme/data/custom_store';

import { ColumnInfo } from '../../domain-info/ColumnInfo';
import { HttpClient } from '@angular/common/http';
import { ActionInfo } from '../../domain-info/ActionInfo';
import { IDomainListService } from 'src/app/services/domain-list-service-base.service';

// Описание tooltip
interface CurrentTooltipInfo {
  target: string
  tooltip: string
  rowId: string
}

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
  selector: 'app-domain-grid',
  templateUrl: './domain-grid.component.html',
  styles: [
  ]
})
export class DomainGridComponent implements OnInit {
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

  getRouteForAction(id: number, actionInfo: InternalActionInfo): Array<string> {
    const routeInfo: string[] = []
    if (!!actionInfo.href) {
      routeInfo.push(actionInfo.href)
    } else {
      //routeInfo = this.getMainRoutingInfo();
      routeInfo.push('item')
      routeInfo.push(id.toString())
    }
    return routeInfo;
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

  // Разобрать список действий в колонке действий
  parsedActions(column: any): InternalActionInfo[] {
    return []

    const data = column.data;
    const actionInfos = data.actions as ActionInfo[];

    if (!!actionInfos) {
      const ops: InternalActionInfo[] = []
      actionInfos.forEach(e => {
        ops.push(this.parseOperation(data.id, e))
      })

      return ops;
    }
    else {
      return []
    }
  }

  private parseOperation(dataId: number, op: ActionInfo): InternalActionInfo {
    return {
      objId: dataId.toString(),
      trackBy: op.operation + dataId,
      id: op.operation,
      isServerSide: false,
      glyph: op.glyph ?? "err",
      tooltip: op.tooltip ?? "Непонятно",
      href: op.endpoint ?? "notfound"
    }
  }

  //#region Подсказки по действиям
  currentTooltip?: CurrentTooltipInfo;

  // Отрабразить тултип для действия
  showOperationTooltip($event: any, action: InternalActionInfo) {
    console.log("showOperationTooltip")
    if (!this.currentTooltip || this.currentTooltip.target != $event.target.id) {
      this.currentTooltip = {
        target: $event.target.id,
        tooltip: action.tooltip + " " + $event.target.id,
        rowId: action.objId
      }
    }
  }

  // Скрыть тултип действия
  hideOperationTooltip($event: any) {
    this.currentTooltip = undefined;
  }
  //#endregion 

}
