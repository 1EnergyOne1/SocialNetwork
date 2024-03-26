using Api.Data;
using Api.Data.Models;
using Api.Main.ADORepository;
using Microsoft.AspNetCore.Mvc;

namespace Api.Main.Services
{
    public class Users
    {
        Repository.Users users = new Repository.Users();
        UsersADORepository repositoryADO = new UsersADORepository();
        public async Task<User?> GetUser(string login, string password, CancellationToken ct)
        {            
            //return await users.GetUserAsync(login, password, ct);
            return await repositoryADO.GetUserAsync(login, password, ct);
        }

        public Task<IEnumerable<User>?> GetAllUsers(CancellationToken ct)
        {
            //return users.GetAllUsers(ct);
            return repositoryADO.GetAllUsersAsync();
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

        public Task<User?> AddAdmin(User user, CancellationToken ct)
        {
            return users.AddAdmin(user, ct);
        }
    }
}
