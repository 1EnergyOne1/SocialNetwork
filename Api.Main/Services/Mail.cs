using Api.Main.Repository;

namespace Api.Main.Services
{
    public class Mail
    {
        private readonly MailRepository repository = new MailRepository();

        //public async Task<IEnumerable<Api.Data.Models.Mail>?> GetAllMails(CancellationToken ct)
        //{
        //    return await repository.GetAllMails(ct);
        //}

        //public async Task<IEnumerable<Api.Data.Models.Mail>?> GetAllMailsForUser(int userId, CancellationToken ct)
        //{
        //    return await repository.GetAllMailsForUser(userId, ct);
        //}

        //public async Task<Api.Data.Models.Mail?> GetMail(int mailId, CancellationToken ct)
        //{
        //    return await repository.GetMail(mailId, ct);
        //}

        //public async Task<Api.Data.Models.Mail?> AddMail(Api.Data.Models.Mail mail, CancellationToken ct)
        //{
        //    return await repository.AddMail(mail, ct);
        //}

        //public async Task<Api.Data.Models.Mail?> UpdateMail(Api.Data.Models.Mail mail, CancellationToken ct)
        //{
        //    return await repository.UpdateMail(mail, ct);
        //}

        //public async Task<bool?> DeleteMail(int mailId, CancellationToken ct)
        //{
        //    return await repository.DeleteMail(mailId, ct);
        //}
    }
}
