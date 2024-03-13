import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { User } from "src/models/user";

@Injectable()
export class UserServices {
    constructor(private _http: HttpClient) { }
    getAllUsers() {
        return this._http.get(`https://localhost:7164/api/users/GetAllUsers`);
    }

    getUser(login: string, password: string) {
        let s = this._http.get(`https://localhost:7164/api/users/GetUser?login=${login}&password=${password}`);
        return s;
    }

    updateUser(user: User) {
        const serializedUser = JSON.stringify(user);
        return this._http.put(`https://localhost:7164/api/users/UpdateUser`, serializedUser).toPromise()
    }

    addUser(user: User) {
        const serializedUser = JSON.stringify(user);
        return this._http.post(`https://localhost:7164/api/users/AddUser`, serializedUser);
    }

    deleteUser(userId: number) {
        return this._http.get(`https://localhost:7164/api/users/DeleteUser?id=${userId}`);
    }
}