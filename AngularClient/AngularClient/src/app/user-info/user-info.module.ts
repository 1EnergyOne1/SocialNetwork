import { NgModule } from '@angular/core';
import { UserInfoComponent } from './user-info.component';
import { HttpClientModule } from '@angular/common/http';
import { UserServices } from 'src/Services/UserService';

@NgModule({
  declarations: [UserInfoComponent
  ],
  imports: [
    HttpClientModule
  ],
  exports: [UserInfoComponent],
  providers: [UserServices]
})
export class UserInfoModule { }
