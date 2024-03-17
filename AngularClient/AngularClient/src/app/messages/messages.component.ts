import { Component, Input } from "@angular/core";
import { MailServices } from "src/Services/MailService";
import { Mail } from "src/models/Mail";
import { User } from "src/models/user";
import { MatDialog } from '@angular/material/dialog';
import { AddMessageComponent } from "./add-message/add-message.component";

@Component({
  selector: 'messages',
  templateUrl: './messages.component.html',
  styleUrls: ['./messages.component.scss']
})
export class MessagesComponent {
  displayedColumns: string[] = ['От кого', 'Дата сообщения', 'Сообщение'];

  @Input()
  user: User = new User();
  mails: Mail[] = [];
  clickedRows = new Set<User>();

  constructor(private _mailService: MailServices, public dialog: MatDialog) { }
  ngOnInit(): void {
    this.getMessagesFromUser();
  }

  async getMessagesFromUser() {
    this._mailService.getAllMailsForUser(this.user.id).then(
      result => {
        this.mails = result as Mail[];
      },
      error => {

      }
    );
  }

  async addMail() {
    const dialogRef = this.dialog.open(AddMessageComponent, {
      data: {

      },
      height: '60%',
      width: '30%'
    });
    dialogRef.afterClosed().subscribe(result => {
      this.getMessagesFromUser();
    });
  }

  async deleteMail() {
    this.clickedRows.forEach(element => {
      if (element.id)
        this._mailService.deleteMail(element.id).then(
          result => {
            this.getMessagesFromUser();
          },
          error => {
          }
        )
    })
  }
}