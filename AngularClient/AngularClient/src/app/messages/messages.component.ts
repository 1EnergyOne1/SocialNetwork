import { Component, Input } from "@angular/core";
import { UserServices } from "src/Services/UserService";
import { User } from "src/models/user";

@Component({
  selector: 'messages',
  templateUrl: './messages.component.html',
  styleUrls: ['./messages.component.scss']
})
export class MessagesComponent {

  @Input()
  user: User = new User();
  users: User[] = [];

  constructor(private _UserServices: UserServices) { }

  async updateUser() {
    this._UserServices.getAllUsers().then(
      result => {
        let s = result;
      },
      error => {
        let r = error;
      }
    );
  }
}