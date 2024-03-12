import { NgModule } from '@angular/core';
import { AuthorizationComponent } from './authorization.component';
import { HttpClientModule } from '@angular/common/http';
import { UserServices } from 'src/Services/UserService';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { MainUserViewModule } from '../main-user-view/main-user-view.module';

@NgModule({
  declarations: [AuthorizationComponent
  ],
  imports: [
    HttpClientModule,
    FormsModule,
    CommonModule,
    MainUserViewModule
  ],
  exports: [AuthorizationComponent],
  providers: [UserServices]
})
export class AuthorizationModule { }
