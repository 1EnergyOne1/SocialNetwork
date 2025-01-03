import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Mail } from "src/models/Mail";
import { User } from "src/models/user";

@Injectable()
export class MailServices {
    constructor(private _http: HttpClient) { }
    getAllMails() {
        return this._http.get(`https://localhost:7164/api/mail/GetAllMails`).toPromise();
    }

    getAllMailsForUser(userId?: number) {
        return this._http.get(`https://localhost:7164/api/mail/GetAllMailsForUser?userId=${userId}`).toPromise();
    }

    async getMail(mailId: number) {
        return this._http.get(`https://localhost:7164/api/mail/GetMail?mailId=${mailId}`).toPromise();
    }

    addMail(mail: Mail) {
        return this._http.post(`https://localhost:7164/api/mail/AddMail`, mail).toPromise();
    }

    deleteMail(mailId: number) {
        return this._http.delete(`https://localhost:7164/api/mail/DeleteMail?mailId=${mailId}`).toPromise();
    }
}