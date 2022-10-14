import { Component, Input, OnInit } from '@angular/core';
import { SprBaseEntity } from '../spr-base-edit/spr-base-entity';

@Component({
  selector: 'app-spr-base',
  templateUrl: './spr-base.component.html'
})
export class SprBaseComponent implements OnInit {

  @Input()
  isTree: boolean = true

  @Input()
  entity?: SprBaseEntity

  testMessage?: string
  saveForm(){
    this.testMessage = "СООБЩЕНИЕ"
  }

  constructor() { }

  ngOnInit(): void {
  }

}
