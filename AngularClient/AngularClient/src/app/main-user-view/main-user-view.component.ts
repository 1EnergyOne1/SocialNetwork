import { Component, Input } from "@angular/core";
import { UserServices } from "src/Services/UserService";
import { User } from "src/models/user";

@Component({
  selector: 'main-user-view',
  templateUrl: './main-user-view.component.html',
  styleUrls: ['./main-user-view.component.scss']
})
export class MainUserViewComponent {

  @Input()
  user: User = new User();

  constructor(private _UserServices: UserServices) { }

  async updateUser() {
    this._UserServices.updateUser(this.user).then(
      result => {
        this.user = result as User;
      },
      error => {

      }
    );
  }
}