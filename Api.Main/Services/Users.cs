using Api.Data.Models;

namespace Api.Main.Services
{
    public class Users
    {
        Repository.Users users = new Repository.Users();
        public User GetUsers(string login, string password)
        {  
            return users.GetUsers(login, password);
        }
    }
}
