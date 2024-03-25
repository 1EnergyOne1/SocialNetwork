using Api.Data.Models;
using Api.Data;
using System.Text.Json;

namespace WebClientMVC.Repository
{
    public class UserRepository
    {
        private HttpClient httpClient = new HttpClient();

        public async Task<User?> GetUser(string login, string password)
        {
            try
            {
                var response = await httpClient.GetAsync($"https://localhost:7164/api/users/GetUser?login={login}&password={password}").ConfigureAwait(false);
                var res = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                var user = JsonSerializer.Deserialize<DtoUser>(res);
                return (User)user;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<User>?> GetAllUsers()
        {
            List<User> Users = new List<User>();
            try
            {
                var response = await httpClient.GetAsync($"https://localhost:7164/api/users/GetAllUsers").ConfigureAwait(false);
                var res = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                var users = JsonSerializer.Deserialize<IEnumerable<DtoUser>>(res);

                foreach(var user in users)
                {
                    Users.Add((User)user);
                }
                return Users;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<User?> AddUser(string login, string password)
        {
            try
            {
                User newUser = new User();
                newUser.Login = login;
                newUser.Password = password;
                newUser.Name = login;
                var jsonContent = JsonContent.Create(newUser);
                var response = await httpClient.PostAsync($"https://localhost:7164/api/users/AddUser", jsonContent).ConfigureAwait(false);
                var res = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                var user = JsonSerializer.Deserialize<DtoUser>(res);
                return (User)user;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<User?> UpdateUser(User user)
        {
            try
            {
                var jsonContent = JsonContent.Create(user);
                var response = await httpClient.PutAsync($"https://localhost:7164/api/users/UpdateUser", jsonContent).ConfigureAwait(false);
                var res = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                var forDtoUser = JsonSerializer.Deserialize<DtoUser>(res);
                return (User)forDtoUser;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<bool?> DeleteUser(User user)
        {
            try
            {
                var jsonContent = JsonContent.Create(user);
                var response = await httpClient.DeleteAsync($"https://localhost:7164/api/users/DeleteUser?id={user.Id}").ConfigureAwait(false);
                var res = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                return true;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<User?> AddAdmin(User user)
        {
            try
            {                
                var jsonContent = JsonContent.Create(user);
                var response = await httpClient.PostAsync($"https://localhost:7164/api/users/AddAdmin", jsonContent).ConfigureAwait(false);
                var res = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                var newUser = JsonSerializer.Deserialize<DtoUser>(res);
                return (User)newUser;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
