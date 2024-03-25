using Api.Data;
using Api.Data.Models;
using WebClientMVC.Repository;

namespace WebClientMVC.Services
{
    public class UserService
    {
        private readonly UserRepository _repository = new UserRepository();

        public Task<User?> GetUser(string login, string password)
        {
            return _repository.GetUser(login, password);
        }

        public Task<List<User>?> GetAllUsers()
        {
            return _repository.GetAllUsers();
        }

        public Task<User?> AddUser(string login, string password)
        {
            return _repository.AddUser(login, password);
        }

        public Task<User?> UpdateUser(User user)
        {
            return _repository.UpdateUser(user);
        }

        public Task<bool?> DeleteUser(User user)
        {
            return _repository.DeleteUser(user);
        }
    }
}
