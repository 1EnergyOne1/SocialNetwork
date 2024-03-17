using Api.Data;
using Api.Data.Models;
using Api.Data.SocialhubContext;
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

        public async Task<IEnumerable<Mail>?> GetAllMailsForUser(int fromUserId, CancellationToken ct)
        {
            try
            {
                return await db.Mails.Where(x => x.FromUserId == fromUserId).ToArrayAsync(ct);
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
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<User?> AddUser(User user, CancellationToken ct)
        {
            try
            {
                if (user.Isadmin)
                {
                    user.Isadmin = false;
                }
                db.Users.Add(user);
                db.SaveChanges();
                return await db.Users.Where(x => x.Login == user.Login && x.Password == user.Password).FirstOrDefaultAsync(ct);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
