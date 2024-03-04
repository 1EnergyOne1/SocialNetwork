using Api.Data.Models;

namespace Api.Main.Repository
{
    public partial class Users
    {
       SocialhubContext db = new SocialhubContext();
        public User GetUsers(string login, string password)
        {
            try
            {
                User user = new User();
                user.Name = "Антон";
                user.LastName = "Бойко";
                user.login = login;
                user.password = password;
                user.isAdmin = true;
                db.User.Add(user);
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
