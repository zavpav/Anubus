import { environment } from "src/environments/environment";
import CustomStore from 'devextreme/data/custom_store';
import * as AspNetData from 'devextreme-aspnet-data-nojquery';
import { Observable, map } from "rxjs";
import { ColumnInfo } from "../../domain-info/ColumnInfo";
import { HttpClient } from "@angular/common/http";
import { MetaInformation, MetaInformationService } from "../../domain-info/MetaInformation";

export class DomainGridServices {
    constructor(
        private http: HttpClient,
        private serverEndpoint: string
    ) {

    }


    // Получить endpoint на информацию по домену
    getColumnInfoEndpoint(): string {
        return environment.mainEndpoint + this.serverEndpoint + "/ListColumnInfo"
    }

    // Получить поток columnInfo с сервера
    getColumnsInfo(): Observable<ColumnInfo[]> {
        return this.http.get(this.getColumnInfoEndpoint())
            .pipe(map(metaInfos => {
                const columnInfos: ColumnInfo[] = []
                for (let mi of <MetaInformation[]>metaInfos) {
                    const ci: ColumnInfo = {
                        caption: mi.caption ?? "undef",
                        dataField: mi.dataField,
                        dataType: mi.type,
                    }
                    columnInfos.push(ci)
                }

                return columnInfos
            }))
    }

    // Получить endpoint на список
    getListEndpoint(): string {
        return environment.mainEndpoint + this.serverEndpoint + "/List"
    }

    // Создать store для данных списка
    createDefaultDataStore(): CustomStore<any, any> {
        return AspNetData.createStore({
            key: 'id',
            loadUrl: this.getListEndpoint(),
            onBeforeSend: (operation: string, ajaxSettings: { data?: any }) => {
                if (operation == "load") {
                    //                            cntx.fillObjAsField(ajaxSettings.data);
                }
            },
            onLoaded: (result: Array<any>) => {
                return []
            },
            loadMode: "processed"
        });

    }
}