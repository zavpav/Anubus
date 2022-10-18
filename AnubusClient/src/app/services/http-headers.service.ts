import { Injectable } from '@angular/core';
import { AuthService } from './auth.service';
import { ServerNotifierService } from './server-notifier.service';

// Сервис "обязательных заголовков" запросов.
// Используется при инъекциях http и при создании dataStorage, так как devextreme не использует нормальный httpClient
@Injectable({
  providedIn: 'root'
})
export class HttpHeadersService {

  constructor(
    private serverNotifierService: ServerNotifierService,
    private authService: AuthService
  ) { }

  getHeaders(): [string, string][] {
    const res: [string, string][] = []
    if (this.serverNotifierService.connectionId) {
      res.push(['x-signalr-connection', this.serverNotifierService.connectionId])
    }
    if (this.authService.isLoggedIn()) {
      res.push(['AUTH', "AUTH"])
    }

    return res
  }
}
