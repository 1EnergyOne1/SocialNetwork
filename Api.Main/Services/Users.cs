using Api.Data.Models;

namespace Api.Main.Services
{
    public class Users
    {
        public User GetUsers(User user)
        {   
            if(user.Name == null)
                user.Name = "Антон";
            if(user.LastName == null)
                user.LastName = "Бойко";
            if(user.Age == null)
                user.Age = 28;
            if(user.login == null)
                user.login = "energyone";
            if(user.password == null)
                user.password = "password";
            return user;
        }
    }
}
