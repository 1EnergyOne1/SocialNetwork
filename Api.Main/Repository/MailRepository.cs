using Api.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Main.Repository
{
    public class MailRepository
    {
        SocialhubContext db = new SocialhubContext();
        public async Task<IEnumerable<Mail>?> GetAllMails(CancellationToken ct)
        {
            try
            {
                return await db.Mails.ToArrayAsync(ct);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<IEnumerable<Mail>?> GetAllMailsForUser(int userId, CancellationToken ct)
        {
            try
            {
                return await db.Mails.Where(x => x.UserId == userId).ToArrayAsync(ct);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<Mail?> GetMail(int mailId, CancellationToken ct)
        {
            try
            {
                return await db.Mails.Where(x => x.Id == mailId).FirstOrDefaultAsync(ct);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<Mail?> AddMail(Mail mail, CancellationToken ct)
        {
            try
            {
                db.Mails.Add(mail);
                db.SaveChanges();
                return await db.Mails.Where(x => x.Message == mail.Message).FirstOrDefaultAsync(ct);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<Mail?> UpdateMail(Mail mail, CancellationToken ct)
        {
            try
            {
                db.Mails.Update(mail);
                db.SaveChanges();
                return await db.Mails.Where(x => x.Id == mail.Id).FirstOrDefaultAsync(ct);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<bool?> DeleteMail(int mailId, CancellationToken ct)
        {
            try
            {
                var res = await db.Mails.Where(x => x.Id == mailId).FirstOrDefaultAsync(ct);
                db.Mails.Remove(res);
                return true;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
