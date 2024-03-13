import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { UserServices } from 'src/Services/UserService';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { AllUsersComponent } from './all-users.component';
import { MatTableModule } from '@angular/material/table';

@NgModule({
  declarations: [AllUsersComponent
  ],
  imports: [
    HttpClientModule,
    FormsModule,
    CommonModule,
    MatButtonModule,
    MatInputModule,
    MatTableModule
  ],
  exports: [AllUsersComponent],
  providers: [UserServices]
})
export class AllUsersModule { }
