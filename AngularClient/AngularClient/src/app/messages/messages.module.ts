import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { UserServices } from 'src/Services/UserService';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MessagesComponent } from './messages.component';
import {MatTableModule} from '@angular/material/table';
import { MailServices } from 'src/Services/MailService';

@NgModule({
  declarations: [MessagesComponent
  ],
  imports: [
    HttpClientModule,
    FormsModule,
    CommonModule,
    MatButtonModule,
    MatInputModule,
    MatTableModule
  ],
  exports: [MessagesComponent],
  providers: [MailServices]
})
export class MessagesModule { }
