using Api.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WPFClient.Repository
{
    public partial class Authorization
    {
        HttpClient httpClient = new HttpClient();
        public async Task<User> GetUser(string login, string password)
        {
            User user = new User();
            user.login = login;
            user.password = password;
            using var requestPost = await httpClient.GetAsync($"https://localhost:7164/api/users/GetUser?login={login}&password={password}");
            var result = await requestPost.Content.ReadFromJsonAsync<User>();
            return user;
        }
    }
}
