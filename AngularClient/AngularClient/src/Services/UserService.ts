import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { User } from "src/models/user";

@Injectable()
export class UserServices {
    constructor(private _http: HttpClient) { }
    getAllUsers() {
        return this._http.get(`https://localhost:7164/api/users/GetAllUsers`).toPromise();
    }

    async getUser(login: string, password: string) {
        return await this._http.get(`https://localhost:7164/api/users/GetUser?login=${login}&password=${password}`).toPromise();
    }

    updateUser(user: User) {
        const serializedUser = JSON.stringify(user);
        return this._http.put(`https://localhost:7164/api/users/UpdateUser`, user).toPromise()
    }

    addUser(user: User) {
        const serializedUser = JSON.stringify(user);
        return this._http.post(`https://localhost:7164/api/users/AddUser`, serializedUser).toPromise();
    }

    deleteUser(userId: number) {
        return this._http.get(`https://localhost:7164/api/users/DeleteUser?id=${userId}`).toPromise();
    }
}