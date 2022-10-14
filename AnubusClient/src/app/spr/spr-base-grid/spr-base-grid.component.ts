import { Component, Input, OnInit } from '@angular/core';
import { IDomainListService } from 'src/app/services/domain-list-service-base.service';

@Component({
  selector: 'app-spr-base-grid',
  templateUrl: './spr-base-grid.component.html',
  styles: [
  ]
})
export class SprBaseGridComponent implements OnInit {
  @Input()
  gridService?: IDomainListService

  constructor() { }

  ngOnInit(): void {
  }

}
