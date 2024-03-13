import { Component, Input, OnInit } from "@angular/core";
import { UserServices } from "src/Services/UserService";
import { Mail } from "src/models/Mail";
import { User } from "src/models/user";

@Component({
    selector: 'all-users',
    templateUrl: './all-users.component.html',
    styleUrls: ['./all-users.component.scss']
})
export class AllUsersComponent implements OnInit {
    displayedColumns: string[] = ['Имя', 'Фамилия', 'Возраст', 'Логин', 'Пароль'];
    clickedRows = new Set<Mail>();
    @Input()
    user: User = new User();
    users: User[] = [];

    constructor(private _UserServices: UserServices) { }
    ngOnInit(): void {
        this.getAllUsers();
    }

    async getAllUsers() {
        this._UserServices.getAllUsers().then(
            result => {
                this.users = result as User[];
                let s = this.users;
            },
            error => {

            }
        );
    }

    async addUser() {
        
    }

    async deleteUser() {

    }
}