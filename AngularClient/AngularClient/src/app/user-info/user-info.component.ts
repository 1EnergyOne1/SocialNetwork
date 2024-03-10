import { HttpClient } from "@angular/common/http";
import { Component } from "@angular/core";
import { UserServices } from "src/Services/UserService";

@Component({
  selector: 'user-info',
  templateUrl: './user-info.component.html',
  styleUrls: ['./user-info.component.scss']
})
export class UserInfoComponent {

  response: string = '';

  constructor(private _http: HttpClient, private _UserServices: UserServices) { }

  async getResponse() {
    this._UserServices.getUser().subscribe({
      next: (data: any) => {
        this.response = data.result;
      }
    })
  }

  async exportToExcel(): Promise<void> {
    return import("xlsx-js-style").then(xlsx => {
      let res = ['Привет', 'Я', 'из', 'другой', 'страны'];
      let headerArrayOfArray = [];
      headerArrayOfArray.push(['Привет', 'Мир']);
      /* const alignment = { vertical: 'center', horizontal: 'center' }; */
      const cellStyle = { alignment: { vertical: "center", horizontal: "top", wrapText: "1" } };
      const styleHeader = {
        font: {
          bold: true,
          sz: 14,
          color: { rgb: "green" },
        }
      }

      const dataForXlsx: any[] = [
        ['Название Клиента', 'Проект', 'Q1', '', 'Q2', '', 'Q3', '', 'Q4', '', '2023'],
        ['', '', 'План', 'Факт', 'План', 'Факт', 'План', 'Факт', 'План', 'Факт', 'План', 'Факт'],
      ]

      const worksheet = xlsx.utils.aoa_to_sheet(dataForXlsx, { cellDates: true })

      // Создадим объекты со стилями
      const alignment = { vertical: 'center', horizontal: 'center' }

       const styleHeaderTitle = {
        alignment: alignment,
        font: {
          bold: true,
          sz: 14,
          color: { rgb: "black" },
        },
      }

      const styleHeaderPlan = {
        alignment: alignment,
        font: {
          bold: true,
          sz: 14,
          color: { rgb: "5082e6" },
        },
      }

      const styleHeaderFact = {
        alignment: alignment,
        font: {
          bold: true,
          sz: 14,
          color: { rgb: "34a853" },
        },
      } 

      // массивы с названием ячеек которые стилизуем
      const cellsTitls = ['C1', 'E1', 'G1', 'I1', 'K1',]
      const cellTitlsPlan = ['C2', 'E2', 'G2', 'I2', 'K2']
      const cellTitlsFact = ['D2', 'F2', 'H2', 'J2', 'L2']

      worksheet['A1'].s = { font: { bold: true, sz: 14, color: { rgb: "black" }, } }
      worksheet['B1'].s = { font: { bold: true, sz: 14, color: { rgb: "black" }, } }

      // Проходим циклами по ячейкам и добавляем им стили
       cellsTitls.forEach(cell => {
        worksheet[cell].s = styleHeaderTitle
      })

      cellTitlsPlan.forEach(cell => {
        worksheet[cell].s = styleHeaderPlan
      })

      cellTitlsFact.forEach(cell => {
        worksheet[cell].s = styleHeaderFact
      }) 


      worksheet['!cols'] = [
        { wpx: 250 },
        { wpx: 250 },
        { wpx: 100 },
        { wpx: 100 },
        { wpx: 100 },
        { wpx: 100 },
        { wpx: 100 },
        { wpx: 100 },
        { wpx: 100 },
        { wpx: 100 },
        { wpx: 100 },
        { wpx: 100 },
      ]

      const workbook = xlsx.utils.book_new()
      xlsx.utils.book_append_sheet(workbook, worksheet, 'Page 1')
      xlsx.writeFile(workbook, 'styled excel.xlsx')

      /* worksheet['A1'].s = { font: { bold: true, sz: 14, color: { rgb: "black" }, } }
      worksheet['B1'].s = { font: { bold: true, sz: 14, color: { rgb: "black" }, } }

      xlsx.utils.sheet_add_aoa(worksheet, [headers], { cellStyles: true });
      xlsx.utils.sheet_add_json(worksheet, res, { skipHeader: true, origin: "A2", cellStyles: true }); */
    })
  }
}