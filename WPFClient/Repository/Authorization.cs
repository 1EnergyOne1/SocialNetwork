using Api.Data.Models;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

namespace WPFClient.Repository
{
    public class Authorization
    {
        private HttpClient httpClient = new HttpClient();

        public async Task<User?> GetUserAsync(string login, string password)
        {
            var response = await httpClient.GetAsync($"https://localhost:7164/api/users/GetUser?login={login}&password={password}").ConfigureAwait(false);
            var res = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            var user = JsonSerializer.Deserialize<DtoUser>(res);
            return (User)user;
        }

        public async Task<User?> AddUserAsync(string login, string password)
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
    }
    
}
