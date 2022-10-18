import { HttpClient } from '@angular/common/http';
import { Injectable, Injector } from '@angular/core';
import { DomainListServiceBase } from 'src/app/services/domain-list-service-base.service';
import { HttpHeadersService } from 'src/app/services/http-headers.service';
import { IBaseDomain } from 'src/app/shared/domain-info/base-domain-object';

@Injectable({
  providedIn: 'root'
})
export class SprGrbsListService extends DomainListServiceBase<IBaseDomain>{

  constructor(injector: Injector) {
    super(injector, "Spr/Grbs")
  }
}
