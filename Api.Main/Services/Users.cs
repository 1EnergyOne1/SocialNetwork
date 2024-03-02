using Api.Data.Models;

namespace Api.Main.Services
{
    public class Users
    {
        public User GetUsers(string login, string password)
        {   
           User user = new User();
                user.Name = "Антон";
                user.LastName = "Бойко";
                user.Age = 28;
                user.login = login;
            if(user.password == null)
                user.password = password;
            return user;
        }
    }
}
