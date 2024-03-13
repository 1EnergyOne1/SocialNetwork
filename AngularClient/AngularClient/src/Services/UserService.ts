import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { User } from "src/models/user";

@Injectable()
export class UserServices {
    constructor(private _http: HttpClient) { }
    getAllUsers() {
        return this._http.get(`https://localhost:7164/api/users/GetAllUsers`).toPromise();
    }

    getUser(login: string, password: string) {
        return this._http.get(`https://localhost:7164/api/users/GetUser?login=${login}&password=${password}`).toPromise();
    }

    updateUser(user: User) {
        return this._http.put(`https://localhost:7164/api/users/UpdateUser`, user).toPromise()
    }

    addUser(user: User) {
        return this._http.post(`https://localhost:7164/api/users/AddUser`, user).toPromise();
    }

    deleteUser(userId: number) {
        return this._http.get(`https://localhost:7164/api/users/DeleteUser?id=${userId}`).toPromise();
    }
}