import { Injectable } from '@angular/core';
import * as signalR from '@microsoft/signalr';
import { Observable, Subject } from 'rxjs';
import { environment } from 'src/environments/environment';

export interface LongOperationUpdate {

  // ИД подключения signalR
  connectionId: string

  // Уникальный ИД операции
  executionId: string

  // Задача закончена 
  isFinished: boolean

  // Текущий шаг
  currentStep: number

  // Текущая оценка количества шагов
  totalSteps: number

  // Сообщение пользователю 
  message?: string
}

@Injectable({
  providedIn: 'root'
})
export class ServerNotifierService {
  signalConnection: signalR.HubConnection;
  connectionId!: string;

  notifies$: Observable<LongOperationUpdate>

  constructor() {
    this.signalConnection = new signalR.HubConnectionBuilder()
      .configureLogging(signalR.LogLevel.Debug)
      .withUrl(environment.notifyEndpoint + '')
      .build();

    const subject: Subject<LongOperationUpdate> = new Subject<LongOperationUpdate>()

    this.signalConnection.on('notify', data => {
      console.log('notifier', data)
      subject.next(data)
    })

    this.signalConnection.onclose((err?: Error) => {
      if (err) {
        console.log('Ошибка signalR', err)
        subject.error(err)
      } else {
        subject.complete
      }
    })

    this.notifies$ = subject

    this.signalConnection
      .start()
      .then(() => {
        var connectionId = this.signalConnection.connectionId
        if (!connectionId)
          throw new Error("Ошибка подключения к notify")
        this.connectionId = connectionId
      })
      .catch(x => {
        console.error("Notify Error ", x)
        throw new Error("Ошибка подключения к notify")
      })
  }
}
