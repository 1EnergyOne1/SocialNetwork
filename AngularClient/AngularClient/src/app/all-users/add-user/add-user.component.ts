import { Component, Inject } from "@angular/core";
import {
    MatDialog,
    MAT_DIALOG_DATA,
    MatDialogRef,
    MatDialogTitle,
    MatDialogContent,
    MatDialogActions,
    MatDialogClose,
} from '@angular/material/dialog';
import { UserServices } from "src/Services/UserService";
import { User } from "src/models/user";

@Component({
    selector: 'add-user',
    templateUrl: './add-user.component.html',
    styleUrls: ['./add-user.component.scss']
})
export class AddUserComponent {
    user: User = new User();
    count: number = 0;

    constructor(private _UserServices: UserServices, public dialogRef: MatDialogRef<AddUserComponent>,
        @Inject(MAT_DIALOG_DATA) public data: User,) { }

    async addUser() {

        await this._UserServices.getAllUsers().then(
            result => {
                let res = result as User[];
                this.count = res.length;
            }
        );
        this.user.id = this.count + 1;
        await this._UserServices.addUser(this.user).then(
            result => {
                this.dialogRef.close();
            },
            error => {
                console.log("Ошибка добавления пользователя");
            }
        )
    }
}