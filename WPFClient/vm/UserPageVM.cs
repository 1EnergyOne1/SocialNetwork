using Api.Data;
using Api.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFClient.Interface;
using WPFClient.Service;

namespace WPFClient.vm
{
    public class UserPageVM
    {
        public User Data { get; set; }

        Authorization auth = new Authorization();
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
    }
}
