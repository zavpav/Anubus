import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';

import {
  DxMenuModule,
  DxBulletModule,
  DxTemplateModule,
  DxDataGridModule,
  DxTreeListModule,
  DxButtonModule,
  DxTooltipModule,
  DxPopoverModule,

  DxFormModule,
  DxTextBoxModule,
  DxNumberBoxModule,
  DxDateBoxModule,
  DxTabPanelModule
} from 'devextreme-angular';



import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { locale } from 'devextreme/localization';
import { LoginFormComponent } from './login-form/login-form.component';
import { NotfoundFormComponent } from './notfound-form/notfound-form.component';
import { AuthGuardService, AuthService } from './services/auth.service';
import { SprBaseEditComponent } from './spr/spr-base-edit/spr-base-edit.component';

import { SprGrbsEditComponent } from './spr/spr-grbs-edit/spr-grbs-edit.component';
import { SprRzprzEditComponent } from './spr/spr-rzprz-edit/spr-rzprz-edit.component';
import { SprGrbsListComponent } from './spr/spr-grbs-list/spr-grbs-list.component';
import { SprRzprzListComponent } from './spr/spr-rzprz-list/spr-rzprz-list.component';
import { SprBaseTreeComponent } from './spr/spr-base-tree/spr-base-tree.component';
import { DomainGridComponent } from './shared/domain-base-list/domain-grid/domain-grid.component';
import { DomainTreeComponent } from './shared/domain-base-list/domain-tree/domain-tree.component';
import { SprBaseGridComponent } from './spr/spr-base-grid/spr-base-grid.component';


locale('ru')


@NgModule({
  declarations: [
    AppComponent,
    LoginFormComponent,
    NotfoundFormComponent,
    SprBaseEditComponent,
    SprGrbsListComponent,
    SprGrbsEditComponent,
    SprRzprzListComponent,
    SprRzprzEditComponent,
    SprBaseTreeComponent,
    DomainGridComponent,
    DomainTreeComponent,
    SprBaseGridComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,

    DxMenuModule,
    DxBulletModule,
    DxTemplateModule,
    DxDataGridModule,
    DxTreeListModule,
    DxButtonModule,
    DxTooltipModule,
    DxPopoverModule,
    DxTabPanelModule,
    DxFormModule,
    DxTextBoxModule,
    DxNumberBoxModule,
    DxDateBoxModule
  ],
  providers: [
    AuthService,
    AuthGuardService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
