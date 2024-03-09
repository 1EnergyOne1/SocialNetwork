using Api.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WPFClient.Interface;

namespace WPFClient.Repository
{
    public class CRUDUserRepository: IUser
    {
        private HttpClient httpClient = new HttpClient();

        public async Task<IEnumerable<DtoUser>?> GetAllUsers()
        {
            try
            {
                var response = await httpClient.GetAsync($"https://localhost:7164/api/users/GetAllUsers").ConfigureAwait(false);
                var res = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                var users = JsonSerializer.Deserialize<IEnumerable<DtoUser>>(res);
                return users;
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
    }
}
