﻿using Api.Data.Models;
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
using Api.Data;

namespace WPFClient.vm
{
    public class UserVM
    {
        public User Data { get; set; }

        Authorization auth = new Authorization();
        CRUDUser cruduser = new CRUDUser();
        public string Login { get; set; }
        public string Password { get; set; }

        public async Task<bool> getAuthorizationAsync()
        {
            var login = Login;
            var password = Password;
            try
            {
                var res = await auth.GetUser(login, password);
                if (res == null)
                {
                    MessageBox.Show("Такой пользователь не найден. Обратитесь к администратору");
                    return false;
                }                    
                else
                {
                    UserPage page = new UserPage(res);
                    page.Show();
                    return true;
                }                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка подкючения к серверу/ошибка выполения запроса");
                return false;
            }

        }

        public async Task<User?> AddUser()
        {
            var res = await cruduser.AddUser(Login, Password);
            return res;
        }

        public async Task<User?> UpdateUser(User user)
        {
            return await cruduser.UpdateUser(user);
        }

        public async Task<IEnumerable<DtoUser>?> GetAllUsers()
        {
            return await cruduser.GetAllUsers();
        }

        public async Task<bool?> DeleteUser(object user)
        {
            var res = (User)user;
            return await cruduser.DeleteUser(res);
        }
    }
}
