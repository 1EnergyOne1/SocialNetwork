import { Component, Inject, OnInit } from "@angular/core";
import {
    MatDialog,
    MAT_DIALOG_DATA,
    MatDialogRef,
    MatDialogTitle,
    MatDialogContent,
    MatDialogActions,
    MatDialogClose,
} from '@angular/material/dialog';
import { MailServices } from "src/Services/MailService";
import { UserServices } from "src/Services/UserService";
import { Mail } from "src/models/Mail";
import { User } from "src/models/user";

@Component({
    selector: 'add-message',
    templateUrl: './add-message.component.html',
    styleUrls: ['./add-message.component.scss']
})
export class AddMessageComponent implements OnInit {
    mail: Mail = new Mail();
    count: number = 0;
    users: User[] = [];
    selection: any;

    private _userId: number = 0;

    public get userId(): number {
        return this._userId;
    }

    public set userId(value: number) {
        this._userId = value;
        this.mail.userid = value;
    }

    constructor(private _MailServices: MailServices, private _UserServices: UserServices, public dialogRef: MatDialogRef<AddMessageComponent>,
        @Inject(MAT_DIALOG_DATA) public data: Mail,) { }
    ngOnInit(): void {
        this.getAllUsers();
    }

    async getAllUsers() {
        await this._UserServices.getAllUsers().then(
            result => {
                this.users = result as User[];
            }
        )
    }

    async addMail() {

        await this._MailServices.getAllMails().then(
            result => {
                let res = result as Mail[];
                this.count = res.length;
            },
            error => {
                let s = error;
            }
        )
        if (this.count == 0)
            this.mail.id = this.count;
        else
            this.mail.id = this.count + 1;
        this.mail.datesend = new Date();
        await this._MailServices.addMail(this.mail).then(
            result => {
                this.dialogRef.close();
            },
            error => {
                console.log("Ошибка добавления пользователя");
            }
        )
    }
}