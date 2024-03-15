import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { UserServices } from 'src/Services/UserService';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { AllUsersComponent } from './all-users.component';
import { MatTableModule } from '@angular/material/table';
import { AddUserComponent } from './add-user/add-user.component';
import { MatDialogModule } from '@angular/material/dialog';

@NgModule({
  declarations: [AllUsersComponent, AddUserComponent
  ],
  imports: [
    HttpClientModule,
    FormsModule,
    CommonModule,
    MatButtonModule,
    MatInputModule,
    MatTableModule,
    MatDialogModule
  ],
  exports: [AllUsersComponent],
  providers: [UserServices]
})
export class AllUsersModule { }
