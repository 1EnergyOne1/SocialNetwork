import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { AuthorizationModule } from './user-info/authorization.module';
import { ExportToExcelModule } from './export-to-excel/export-to-excel.module';
import { MainUserViewModule } from './main-user-view/main-user-view.module';

@NgModule({
  declarations: [
    AppComponent,
  ],
  imports: [
    BrowserModule,
    CommonModule,
    FormsModule,
    AuthorizationModule,
    ExportToExcelModule,
    MainUserViewModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
