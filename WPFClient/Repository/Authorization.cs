using Api.Data;
using Api.Data.Models;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using WPFClient.Interface;

namespace WPFClient.Repository
{
    public class Authorization: IAuth
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
            catch(Exception ex)
            {
                return null;
            }            
        }
    }
    
}
