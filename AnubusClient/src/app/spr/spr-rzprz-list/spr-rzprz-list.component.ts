import { Component, OnInit } from '@angular/core';
import { SprRzprzListService } from './spr-rzprz-list.service';

@Component({
  selector: 'app-spr-rzprz-list',
  templateUrl: './spr-rzprz-list.component.html',
  styles: [
  ]
})
export class SprRzprzListComponent implements OnInit {

  constructor(public gridService: SprRzprzListService) { }


  ngOnInit(): void {
  }

}
