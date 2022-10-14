import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-spr-rzprz-edit',
  templateUrl: './spr-rzprz-edit.component.html',
  styles: [
  ]
})
export class SprRzprzEditComponent implements OnInit {
  entityId?: number

  constructor(private activatedRoute: ActivatedRoute) { }

  ngOnInit(): void {
    this.entityId = this.activatedRoute.snapshot.params["id"]
  }

}
