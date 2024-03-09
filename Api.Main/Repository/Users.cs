using Api.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NodaTime;

namespace Api.Main.Repository
{
    public partial class Users
    {
       SocialhubContext db = new SocialhubContext();
        public async Task<User?> GetUser(string login, string password, CancellationToken ct)
        {
            try
            {
                return await db.Users.Where(x => x.Login == login && x.Password == password).FirstOrDefaultAsync(ct);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<IEnumerable<User>?> GetAllUsers(CancellationToken ct)
        {
            try
            {
                return await db.Users.ToArrayAsync(ct);
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
                if(user.Isadmin)
                {
                    user.Isadmin = false;
                }                
                user.Datecreate = new LocalDateTime();
                db.Users.Add(user);
                db.SaveChanges();
                return await db.Users.Where(x => x.Login == user.Login && x.Password == user.Password).FirstOrDefaultAsync(ct);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<User?> UpdateUser(User user, CancellationToken ct)
        {
            try
            {               
                db.Users.Update(user);
                db.SaveChanges();
               return await db.Users.Where(x => x.Id == user.Id).FirstOrDefaultAsync(ct);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
