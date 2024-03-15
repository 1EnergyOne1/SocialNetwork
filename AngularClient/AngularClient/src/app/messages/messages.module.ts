import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { CommonModule } from '@angular/common';
import { MatButtonModule } from '@angular/material/button';
import { MessagesComponent } from './messages.component';
import {MatTableModule} from '@angular/material/table';
import { MailServices } from 'src/Services/MailService';
import { AddMessageComponent } from './add-message/add-message.component';
import {FormsModule} from '@angular/forms';
import {MatInputModule} from '@angular/material/input';
import {MatSelectModule} from '@angular/material/select';
import {MatFormFieldModule} from '@angular/material/form-field';

@NgModule({
  declarations: [MessagesComponent, AddMessageComponent
  ],
  imports: [
    HttpClientModule,
    FormsModule,
    CommonModule,
    MatButtonModule,
    MatInputModule,
    MatTableModule,
    MatSelectModule,
    MatFormFieldModule
  ],
  exports: [MessagesComponent],
  providers: [MailServices]
})
export class MessagesModule { }
