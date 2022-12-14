import { Component, Input, OnInit } from '@angular/core';
import { IDomainListService } from 'src/app/services/domain-list-service-base.service';

@Component({
  selector: 'app-spr-base-tree',
  templateUrl: './spr-base-tree.component.html',
  styles: [
  ]
})
export class SprBaseTreeComponent implements OnInit {
  @Input()
  gridService?: IDomainListService

  constructor() { }

  ngOnInit(): void {
  }

}
