import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";

@Injectable()
export class UserServices {
    constructor(private _http: HttpClient) { }
    getUser() {
        let date = new Date();
        let dateNumber = date.toString();
        return this._http.get(`https://localhost:7164/api/users/GetUserWitDateBirth?dateBirth=${dateNumber}`);
    }
}