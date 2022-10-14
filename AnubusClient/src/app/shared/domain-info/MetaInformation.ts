export interface MetaInformation {
    dataField: string
    caption?: string
    type?: string
    isRequire?: boolean
    maxLen?: number
    isReadOnly?: boolean
}

import { Injectable } from '@angular/core'
import { SimpleItem as FormSimpleItem } from 'devextreme/ui/form';

@Injectable({ providedIn: 'root' })
export class MetaInformationService {
    //Создать SimpleItem для формы редактирования
    generateSimpleItemByMetaInformation(metaInformation: MetaInformation, withCaption: boolean = true): FormSimpleItem {
        let editorOptions = {}
        const editorItem: FormSimpleItem = {
            dataField: metaInformation.dataField,
            isRequired: metaInformation.isRequire
        }
        if (withCaption) {
            editorItem.label = {
                text: metaInformation.caption,
            }
        }

        // Настраиваем дату
        if (metaInformation.type == "date") {
            editorItem.editorType = "dxDateBox"
            editorOptions = { ...editorOptions, dataType: 'date', displayFormat: 'dd.MM.yyyy', width: '10em' }
        }

        if (metaInformation.isRequire) {
            if (!editorItem.validationRules) {
                editorItem.validationRules = []
            }

            editorItem.validationRules.push({ type: "required", message: "Поле обязательно" })
        }

        // Настраиваем максимальный размер (для строк)
        if (metaInformation.maxLen && metaInformation.maxLen > 0) {
            if (!editorItem.validationRules) {
                editorItem.validationRules = []
            }
            editorItem.validationRules.push({ type: "stringLength", max: metaInformation.maxLen, message: "Слишком длинная запись" })

            if (metaInformation.maxLen < 52) {
                // Наводим красоту для небольших полей (уменьшаем размер на экране)
                // "+2" - это немного места под фонарь ошибки
                editorOptions = { ...editorOptions, width: (metaInformation.maxLen + 2) + 'em' }
            }
        }

        if (metaInformation?.isReadOnly == true) {
            editorOptions = { ...editorOptions, readOnly: true, inputAttr: { 'style': 'color: gray' } }
        }

        editorItem.editorOptions = editorOptions

        return editorItem;
    }
}

