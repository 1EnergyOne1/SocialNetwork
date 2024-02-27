using Api.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace WPFClient.Service
{
    public static class Authorization
    {
        static HttpClient httpClient = new HttpClient();
        public static async Task<User> GetUser(string login, string password)
        {
            User user = new User();
            user.login = login;
            user.password = password;
            StringContent content = new StringContent("Tony");
            //using var requestPost = await httpClient.Post("https://localhost:7164/api/users/GetUser");
            using var requestPost = new HttpRequestMessage(HttpMethod.Post, "https://localhost:7164/api/users/GetUser");
            requestPost.Content = content;
            using var response = await httpClient.SendAsync(requestPost);
            var result = await requestPost.Content.ReadFromJsonAsync<User>();
            return user;
        }
    }
}
