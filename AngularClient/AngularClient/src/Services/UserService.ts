import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";

@Injectable()
export class UserServices {
    constructor(private _http: HttpClient) { }
    getAllUsers() {
        return this._http.get(`https://localhost:7164/api/users/GetAllUsers`);
    }

    getUser(login: string, password: string) {
        return this._http.get(`https://localhost:7164/api/users/GetUser?login=${login}&password=${password}`);
    }
}