using Api.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WPFClient.Interface;
using Api.Data;

namespace WPFClient.Repository
{
    public class CRUDMailsRepository: IMail
    {
        private HttpClient httpClient = new HttpClient();

        public async Task<IEnumerable<DtoMail>?> GetAllMails()
        {
            try
            {
                var response = await httpClient.GetAsync($"https://localhost:7164/api/mail/GetAllMails").ConfigureAwait(false);
                var res = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                var mails = JsonSerializer.Deserialize<IEnumerable<DtoMail>>(res);
                return mails;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<IEnumerable<DtoMail>?> GetAllMailsForUser(int userId)
        {
            try
            {
                var response = await httpClient.GetAsync($"https://localhost:7164/api/mail/GetAllMailsForUser?userId={userId}").ConfigureAwait(false);
                var res = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                var mails = JsonSerializer.Deserialize<IEnumerable<DtoMail>>(res);
                return mails;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<DtoMail?> GetMail(int mailId)
        {
            try
            {
                var response = await httpClient.GetAsync($"https://localhost:7164/api/mail/GetMail?mailId={mailId}").ConfigureAwait(false);
                var res = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                var mail = JsonSerializer.Deserialize<DtoMail?>(res);
                return mail;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<Mail?> AddMail(Mail mail)
        {
            try
            {
                var jsonContent = JsonContent.Create(mail);
                var response = await httpClient.PostAsync($"https://localhost:7164/api/mail/AddMail", jsonContent).ConfigureAwait(false);
                var res = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                var newMail = JsonSerializer.Deserialize<DtoMail>(res);
                return (Mail)mail;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<Mail?> UpdateMail(Mail mail)
        {
            try
            {
                var jsonContent = JsonContent.Create(mail);
                var response = await httpClient.PutAsync($"https://localhost:7164/api/mail/UpdateMail", jsonContent).ConfigureAwait(false);
                var res = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                var forDtoMail = JsonSerializer.Deserialize<DtoMail>(res);
                return (Mail)forDtoMail;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<bool?> DeleteMail(Mail mail)
        {
            try
            {
                var jsonContent = JsonContent.Create(mail);
                var response = await httpClient.DeleteAsync($"https://localhost:7164/api/mail/DeleteMail?id={mail.Id}").ConfigureAwait(false);
                var res = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                return true;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
