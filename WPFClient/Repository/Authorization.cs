using Api.Data.Models;
using NodaTime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace WPFClient.Repository
{
    internal class Authorization
    {
        private HttpClient httpClient = new HttpClient();
        private static readonly JsonSerializerOptions serializerOptions = new JsonSerializerOptions();
        public async Task<User> GetUserAsync(string login, string password)
        {
            var response = await httpClient.GetAsync($"https://localhost:7164/api/users/GetUser?login={login}&password={password}").ConfigureAwait(false);
            var result = Deserialize(await response.Content.ReadAsByteArrayAsync().ConfigureAwait(false));
            return result;
        }

        private static User Deserialize(byte[] jsonContent)
        {
            return JsonSerializer.Deserialize<User>(jsonContent, serializerOptions);
        }
    }
}
