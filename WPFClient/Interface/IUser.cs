using Api.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFClient.Interface
{
    public partial interface IUser
    {
        public Task<User?> AddUser(string login, string password);

        public Task<User?> UpdateUser(User user);

        public Task<IEnumerable<DtoUser>?> GetAllUsers();
    }
}
