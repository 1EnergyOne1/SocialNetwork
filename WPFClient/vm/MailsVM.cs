using Api.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFClient.Service;

namespace WPFClient.vm
{
    public class MailsVM
    {
        public Mail Data { get; set; }
        CRUDMailsService CRUDMailsService { get; set;}

        public async Task<Mail?> AddMail(Mail mail)
        {
            return await CRUDMailsService.AddMail(mail);
        }

        public async Task<Mail?> UpdateMail(Mail mail)
        {
            return await CRUDMailsService.UpdateMail(mail);
        }

        public async Task<IEnumerable<DtoMail>?> GetAllMails()
        {
            return await CRUDMailsService.GetAllMails();
        }

        public async Task<IEnumerable<DtoMail>?> GetAllMailsForUser(int userId)
        {
            return await CRUDMailsService.GetAllMailsForUser(userId);
        }

        public async Task<bool?> DeleteMail(object mail)
        {
            var res = (Mail)mail;
            return await CRUDMailsService.DeleteMail(res);
        }
    }
}
