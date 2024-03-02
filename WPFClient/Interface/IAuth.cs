using Api.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFClient.Service;

namespace WPFClient.Interface
{
    public partial interface IAuth
    {
        public Task<User> GetUser(string login, string password);
    }
}
