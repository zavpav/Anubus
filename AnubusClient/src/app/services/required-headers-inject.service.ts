import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpHeadersService } from './http-headers.service';

// Сервис автоматической инъекции обязательных заголовков в httpClient
@Injectable({
  providedIn: 'root'
})
export class RequiredHeadersInjectService implements HttpInterceptor {

  constructor(
    private httpHeadersService: HttpHeadersService
  ) { }

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {

    let headers = req.headers

    for (let h of this.httpHeadersService.getHeaders()) {
      headers = headers.append(h[0], h[1])
    }

    const newReq = req.clone({ headers })
    return next.handle(newReq)
  }
}
