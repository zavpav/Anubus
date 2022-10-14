import { Component, OnInit } from '@angular/core';
import { SprGrbsListService } from './spr-grbs-list.service';

@Component({
  selector: 'app-spr-grbs-list',
  templateUrl: './spr-grbs-list.component.html',
  styles: [
  ]
})
export class SprGrbsListComponent implements OnInit {

  constructor(public gridService: SprGrbsListService) { }

  ngOnInit(): void {
  }

}
