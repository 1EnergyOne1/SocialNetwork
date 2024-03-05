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

namespace WPFClient.vm
{
    public class UserVM
    {
        public User Data { get; set; }

        Authorization auth = new Authorization();
        public string Login { get; set; }
        public string Password { get; set; }        

        public bool getAuthorizationAsync()
        {
            var login = Login;
            var password = Password;
            var res = auth.GetUser(login, password);
            if (res.Id != null)
            {
                UserPage page = new UserPage();
                MainWindow main = new MainWindow();                
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
