import { Component, Input } from "@angular/core";
import { MailServices } from "src/Services/MailService";
import { Mail } from "src/models/Mail";
import { User } from "src/models/user";

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

  constructor(private _mailService: MailServices) { }
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

  }

  async deleteMail() {

  }
}