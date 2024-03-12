import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { UserServices } from 'src/Services/UserService';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { MainUserViewComponent } from './main-user-view.component';

@NgModule({
  declarations: [MainUserViewComponent
  ],
  imports: [
    HttpClientModule,
    FormsModule,
    CommonModule
  ],
  exports: [MainUserViewComponent],
  providers: [UserServices]
})
export class MainUserViewModule { }
