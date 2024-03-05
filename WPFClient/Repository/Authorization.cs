using Api.Data.Models;
using System.Net.Http;
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
    }
}
