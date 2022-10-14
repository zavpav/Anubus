import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-spr-grbs-edit',
  templateUrl: './spr-grbs-edit.component.html',
  styles: [
  ]
})
export class SprGrbsEditComponent implements OnInit {
  entityId?: number

  constructor(private activatedRoute: ActivatedRoute) { }

  ngOnInit(): void {
    this.entityId = this.activatedRoute.snapshot.params["id"]
  }

}
