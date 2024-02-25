import { HttpClient } from "@angular/common/http";
import { Component } from "@angular/core";
import { UserServices } from "src/Services/UserService";

@Component({
  selector: 'user-info',
  templateUrl: './user-info.component.html',
  styleUrls: ['./user-info.component.scss']
})
export class UserInfoComponent {

  response: string = '';

  constructor(private _http: HttpClient, private _UserServices: UserServices) { }

  getResponse() {
    this._UserServices.getUser().subscribe({next: (data:any) =>{
      this.response = data.result;
    }})
  }
}