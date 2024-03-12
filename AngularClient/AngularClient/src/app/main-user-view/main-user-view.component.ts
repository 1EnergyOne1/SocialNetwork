import { Component } from "@angular/core";
import { UserServices } from "src/Services/UserService";
import { User } from "src/models/user";

@Component({
  selector: 'main-user-view',
  templateUrl: './main-user-view.component.html',
  styleUrls: ['./main-user-view.component.scss']
})
export class MainUserViewComponent {

  login: string = "";
  password: string = "";
  user: User = new User();

  constructor(private _UserServices: UserServices) { }

  async getUser(){

  }

  /* async getUsers() {
    this._UserServices.getAllUsers().subscribe({
      next: (data: any) => {
        this.users = data.result;
      }
    })
  } */
}