import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { DomainListServiceBase } from 'src/app/services/domain-list-service-base.service';
import { IBaseDomain } from 'src/app/shared/domain-info/base-domain-object';

@Injectable({
  providedIn: 'root'
})
export class SprRzprzListService extends DomainListServiceBase<IBaseDomain>{

  constructor(http: HttpClient) {
    super(http, "Spr/RzPrz")
  }
}
