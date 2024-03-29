import { Component } from "@angular/core";
import { MongoServices } from "src/Services/MongoService";
import { UserServices } from "src/Services/UserService";
import { User } from "src/models/user";

@Component({
  selector: 'authorization',
  templateUrl: './authorization.component.html',
  styleUrls: ['./authorization.component.scss']
})
export class AuthorizationComponent {

  public login: string = "";
  public password: string = "";
  user: User = new User();
  Islogged: boolean = false;

  constructor(private _UserServices: UserServices, private _mongoService: MongoServices) { }

  async getUser() {
    await this._mongoService.getUser("Antony").then(
      result => {
        let s = result;
      },
      error => {
        let r = error;
      }
    );  

    await this._UserServices.getUser(this.login, this.password).then(
      result => {
        this.user = result as User;
        let s = this.user;
        this.Islogged = true;
      },
      error => {

      }
    );
  }
}