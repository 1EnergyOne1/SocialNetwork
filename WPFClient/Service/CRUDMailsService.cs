using Api.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFClient.Interface;
using WPFClient.Repository;

namespace WPFClient.Service
{
    public class CRUDMailsService: IMail
    {
        private readonly CRUDMailsRepository CRUDMail = new CRUDMailsRepository();

        //public async Task<Mail?> AddMail(Mail mail)
        //{
        //    return await CRUDMail.AddMail(mail);
        //}

        //public async Task<IEnumerable<DtoMail>?> GetAllMails()
        //{
        //    return await CRUDMail.GetAllMails();
        //}

        //public async Task<Mail?> UpdateMail(Mail mail)
        //{
        //    return await CRUDMail.UpdateMail(mail);
        //}

        //public async Task<bool?> DeleteMail(Mail mail)
        //{
        //    return await CRUDMail.DeleteMail(mail);
        //}

        //public async Task<IEnumerable<DtoMail>?> GetAllMailsForUser(int userId)
        //{
        //    return await CRUDMail.GetAllMailsForUser(userId);
        //}

        //public async Task<DtoMail?> GetMail(int mailId)
        //{
        //    return await CRUDMail.GetMail(mailId);
        //}
    }
}
