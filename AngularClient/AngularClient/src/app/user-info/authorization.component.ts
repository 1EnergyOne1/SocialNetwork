import { Component } from "@angular/core";
import { UserServices } from "src/Services/UserService";
import { User } from "src/models/user";

@Component({
  selector: 'authorization',
  templateUrl: './authorization.component.html',
  styleUrls: ['./authorization.component.scss']
})
export class AuthorizationComponent {

  public login: string = "energyone";
  public password: string = "4876";
  user: User = new User();
  Islogged: boolean = false;

  constructor(private _UserServices: UserServices) { }

  async getUser() {
    this._UserServices.getUser(this.login, this.password).then(
      result => {
        var s = result;
        /* this.user = (User)s; */
        this.Islogged = true;
      },
      error => {

      }
    );
  }
}