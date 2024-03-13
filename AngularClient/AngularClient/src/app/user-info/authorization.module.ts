import { NgModule } from '@angular/core';
import { AuthorizationComponent } from './authorization.component';
import { HttpClientModule } from '@angular/common/http';
import { UserServices } from 'src/Services/UserService';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { MainUserViewModule } from '../main-user-view/main-user-view.module';
import {MatButtonModule} from '@angular/material/button';
import {MatInputModule} from '@angular/material/input';
import {MatTabsModule} from '@angular/material/tabs';
import { MessagesModule } from '../messages/messages.module';

@NgModule({
  declarations: [AuthorizationComponent
  ],
  imports: [
    HttpClientModule,
    FormsModule,
    CommonModule,
    MainUserViewModule,
    MatButtonModule,
    MatInputModule,
    MatTabsModule,
    MessagesModule
  ],
  exports: [AuthorizationComponent],
  providers: [UserServices]
})
export class AuthorizationModule { }
