using Api.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFClient.Interface
{
    public partial interface IMail
    {
        public Task<Mail?> AddMail(Mail mail);

        public Task<Mail?> UpdateMail(Mail mail);

        public Task<IEnumerable<DtoMail>?> GetAllMails();
        public Task<IEnumerable<DtoMail>?> GetAllMailsForUser(int userId);
        public Task<bool?> DeleteMail(Mail mail);
        public Task<DtoMail?> GetMail(int mailId);
    }
}
