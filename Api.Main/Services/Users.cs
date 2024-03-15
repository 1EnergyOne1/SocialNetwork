using Api.Data;
using Api.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api.Main.Services
{
    public class Users
    {
        Repository.Users users = new Repository.Users();
        public Task<User?> GetUser(string login, string password, CancellationToken ct)
        {  
            return users.GetUser(login, password, ct);
        }

        public Task<IEnumerable<User>?> GetAllUsers(CancellationToken ct)
        {
            return users.GetAllUsers(ct);
        }

        public Task<User?> AddUser(User user, CancellationToken ct)
        {
            return users.AddUser(user, ct);
        }

        public Task<User?> UpdateUser(User user, CancellationToken ct)
        {
            return users.UpdateUser(user, ct);
        }

        public Task<bool?> DeleteUser(int id, CancellationToken ct)
        {
            return users.DeleteUser(id, ct);
        }
    }
}
