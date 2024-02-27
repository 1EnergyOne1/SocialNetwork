using Api.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFClient.Service;

namespace WPFClient.Interface
{
    internal interface IAuth
    {        
        public Task<User> GetUser(string login, string password)
        {
            return Authorization.GetUser(login, password);
        }
    }
}
