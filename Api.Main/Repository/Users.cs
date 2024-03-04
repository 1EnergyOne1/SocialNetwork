using Api.Data.Models;
using Microsoft.EntityFrameworkCore;
using NodaTime;

namespace Api.Main.Repository
{
    public partial class Users
    {
       SocialhubContext db = new SocialhubContext();
        public Task<User?> GetUsers(string login, string password, CancellationToken ct)
        {
            try
            {
                return db.Users.Where(x => x.Login == login && x.Password == password).FirstOrDefaultAsync(ct);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public User AddUser(string login, string password, bool isAdmin)
        {
            try
            {
                User user = new User();
                user.Name = login;
                user.Login = login;
                user.Password = password;
                if(isAdmin)
                {
                    user.Isadmin = false;
                }                
                user.Datecreate = new LocalDateTime();
                db.Users.Add(user);
                db.SaveChanges();
                return user;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
