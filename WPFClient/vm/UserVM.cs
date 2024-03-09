using Api.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows;
using WPFClient.Service;
using WPFClient.Interface;

namespace WPFClient.vm
{
    public class UserVM
    {
        public User Data { get; set; }

        Authorization auth = new Authorization();
        CRUDUser crudser = new CRUDUser();
        public string Login { get; set; }
        public string Password { get; set; }        

        public async Task<bool> getAuthorizationAsync()
        {
            var login = Login;
            var password = Password;
            var res = await auth.GetUser(login, password);
            if (res.Id != null)
            {
                UserPage page = new UserPage(res);            
                page.Show();
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<User?> AddUser()
        {
            var res = await crudser.AddUser(Login, Password);
            return res;
        }

        public async Task<User?> UpdateUser(User user)
        {
            return await crudser.UpdateUser(user);
        }

        public async Task<IEnumerable<DtoUser>?> GetAllUsers()
        {
            return await crudser.GetAllUsers();
        }
    }
}
