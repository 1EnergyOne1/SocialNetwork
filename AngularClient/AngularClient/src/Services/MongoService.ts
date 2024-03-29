import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { User } from "src/models/user";

@Injectable()
export class MongoServices {
    constructor(private _http: HttpClient) { }
    getUsers() {
        return this._http.get(`https://localhost:7164/api/mongo/GetAll`).toPromise();
    }

    getUser(id: string) {
        return this._http.get(`https://localhost:7164/api/mongo/GetAsync?id=${id}`).toPromise();
    }

    updateUser(user: User) {
        return this._http.put(`https://localhost:7164/api/mongo/UpdateUser`, user).toPromise()
    }

    addUser(user: User) {
        return this._http.post(`https://localhost:7164/api/mongo/AddUser`, user).toPromise();
    }

    deleteUser(userId: number) {
        return this._http.delete(`https://localhost:7164/api/mongo/DeleteUser?id=${userId}`).toPromise();
    }
}