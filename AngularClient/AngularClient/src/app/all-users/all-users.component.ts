import { Component, Input, OnInit } from "@angular/core";
import { UserServices } from "src/Services/UserService";
import { User } from "src/models/user";
import { MatDialog } from '@angular/material/dialog';
import { AddUserComponent } from "./add-user/add-user.component";

@Component({
    selector: 'all-users',
    templateUrl: './all-users.component.html',
    styleUrls: ['./all-users.component.scss']
})
export class AllUsersComponent implements OnInit {
    displayedColumns: string[] = ['Имя', 'Фамилия', 'Возраст', 'Логин', 'Пароль'];
    clickedRows = new Set<User>();
    @Input()
    user: User = new User();
    users: User[] = [];

    constructor(private _UserServices: UserServices, public dialog: MatDialog) { }
    ngOnInit(): void {
        this.getAllUsers();
    }

    async getAllUsers() {
        this._UserServices.getAllUsers().then(
            result => {
                this.users = result as User[];
            },
            error => {

            }
        );
    }

    async addUser() {
        const dialogRef = this.dialog.open(AddUserComponent, {
            data: {

            },
            height: '60%',
            width: '30%'
        });
        dialogRef.afterClosed().subscribe(result => {
            this.getAllUsers();
        });
    }

    async deleteUser() {
        this.clickedRows.forEach(element => {
            if (element.id)
                this._UserServices.deleteUser(element.id).then(
                    result => {
                        this.getAllUsers();
                    },
                    error => {
                    }
                )
        })
    }
}