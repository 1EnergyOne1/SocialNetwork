using Api.Data.Models;

namespace Api.Main.Services
{
    public class Users
    {
        Repository.Users users = new Repository.Users();
        public Task<User?> GetUsers(string login, string password, CancellationToken ct)
        {  
            return users.GetUsers(login, password, ct);
        }
    }
}
