using Api.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using WPFClient.Interface;
using WPFClient.Repository;

namespace WPFClient.Service
{
    public class CRUDUser: IUser
    {
        private readonly CRUDUserRepository CRUDUSer = new CRUDUserRepository();

        public async Task<User?> AddUser(string login, string password)
        {
            return await CRUDUSer.AddUser(login, password);
        }

        public async Task<IEnumerable<DtoUser>?> GetAllUsers()
        {
            return await CRUDUSer.GetAllUsers();
        }

        public async Task<User?> UpdateUser(User user)
        {
            return await CRUDUSer.UpdateUser(user);

        }
    }
}
