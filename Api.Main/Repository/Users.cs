using Api.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NodaTime;

namespace Api.Main.Repository
{
    public partial class Users
    {
       SocialhubContext db = new SocialhubContext();
        public async Task<User> GetUsers(string login, string password, CancellationToken ct)
        {
            try
            {
                var res = await db.Users.Where(x => x.Login == login && x.Password == password).FirstOrDefaultAsync(ct);
                return res;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<User> AddUser(User user, CancellationToken ct)
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
                var res = await db.Users.Where(x => x.Login == user.Login && x.Password == user.Password).FirstOrDefaultAsync(ct);
                return res;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        
    }
}
