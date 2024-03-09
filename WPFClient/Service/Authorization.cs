using Api.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using WPFClient.Interface;

namespace WPFClient.Service
{    
    public class Authorization: IAuth
    {
        private readonly Repository.Authorization authorization = new Repository.Authorization();


        public async Task<User?> GetUser(string login, string password)
        {
            return  await authorization.GetUser(login, password);
        }
    }
}