import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuardService } from './services/auth.service';

import { LoginFormComponent } from './login-form/login-form.component';
import { NotfoundFormComponent } from './notfound-form/notfound-form.component';

import { SprGrbsEditComponent } from './spr/spr-grbs-edit/spr-grbs-edit.component';

import { SprRzprzEditComponent } from './spr/spr-rzprz-edit/spr-rzprz-edit.component';
import { SprGrbsListComponent } from './spr/spr-grbs-list/spr-grbs-list.component';
import { SprRzprzListComponent } from './spr/spr-rzprz-list/spr-rzprz-list.component';


const routes: Routes = [
  {
    path: 'login-form',
    component: LoginFormComponent,
    canActivate: [AuthGuardService]
  },
  {
    path: 'not-found',
    component: NotfoundFormComponent
  },
  {
    path: 'spr/grbs/list',
    component: SprGrbsListComponent,
    //canActivate: [ AuthGuardService ]
  },
  {
    path: 'spr/grbs/entity/:id',
    component: SprGrbsEditComponent,
    //canActivate: [ AuthGuardService ]
  },
  {
    path: 'spr/rzprz/list',
    component: SprRzprzListComponent,
    //canActivate: [ AuthGuardService ]
  },
  {
    path: 'spr/rzprz/entity/:id',
    component: SprRzprzEditComponent,
    //canActivate: [ AuthGuardService ]
  },

  {
    path: '**',
    redirectTo: 'spr/grbs/entity/1'
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
