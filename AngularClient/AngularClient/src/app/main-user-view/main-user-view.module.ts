import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { UserServices } from 'src/Services/UserService';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { MainUserViewComponent } from './main-user-view.component';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';

@NgModule({
  declarations: [MainUserViewComponent
  ],
  imports: [
    HttpClientModule,
    FormsModule,
    CommonModule,
    MatButtonModule,
    MatInputModule
  ],
  exports: [MainUserViewComponent],
  providers: [UserServices]
})
export class MainUserViewModule { }
