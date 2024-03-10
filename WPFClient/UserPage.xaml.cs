using Api.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WPFClient.vm;

namespace WPFClient
{
    /// <summary>
    /// Логика взаимодействия для UserPage.xaml
    /// </summary>
    public partial class UserPage : Window
    {
        UserVM vm = new UserVM();
        public User User { get; set; }        
        List<User> Users = new List<User>();
        public string UserName { get; set; }
        public string UserLastName { get; set; }
        public string UserLogin { get; set; }
        public string UserPassword { get; set; }
        public int? UserAge { get; set; }
        public int TableRowIndex { get; set; }
        public UserPage()
        {
            InitializeComponent();
        }

        public UserPage(User user)
        {
            try
            {
                InitializeComponent();
                this.DataContext = user;
                User = user;
                if (!string.IsNullOrEmpty(user.Name))
                {
                    name.Text = user.Name;
                    UserName = user.Name;
                }
                if (!string.IsNullOrEmpty(user.Lastname))
                {
                    lastName.Text = user.Lastname;
                    UserLastName = user.Lastname;
                }
                if (!string.IsNullOrEmpty(user.Login))
                {
                    login.Text = user.Login;
                    UserLogin = user.Login;
                }
                if (!string.IsNullOrEmpty(user.Password))
                {
                    password.Text = user.Password;
                    UserPassword = user.Password;
                }
                if (!string.IsNullOrEmpty(user.Age.ToString()))
                {
                    age.Text = user.Age.ToString();
                    UserAge = user.Age;
                }
                GetAllUsers();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Ошибка подкючения к серверу/ошибка выполения запроса");
            }            
        }

        private async void GetAllUsers()
        {
            var res = await vm.GetAllUsers();
            if(res != null)
            {
                var DtoUsers = res.ToArray();
                foreach(var DtoUser in DtoUsers)
                {
                    Users.Add((User)DtoUser);
                }
                usersGrid.ItemsSource = Users;
            }            
        }

        private void UnAuthorize(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddUser addUser = new AddUser();
            addUser.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            
            if (User != null)
            {
                var result = vm.UpdateUser(User);
            }
        }

        private void Name(object sender, TextChangedEventArgs e)
        {
            if(!string.IsNullOrEmpty(name.Text))
                User.Name = Convert.ToString(name.Text);
            else
            {
                if(!string.IsNullOrEmpty(User.Name))
                    name.Text = User.Name;
            }
        }

        private void LastName(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(lastName.Text))
                User.Lastname = Convert.ToString(lastName.Text);
            else
            {
                if (!string.IsNullOrEmpty(User.Lastname))
                    lastName.Text = User.Lastname;
            }
        }

        private void Age(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(age.Text))
                    User.Age = Convert.ToInt32(age.Text);
                else
                {
                    if (!string.IsNullOrEmpty(User.Age.ToString()))
                        age.Text = User.Age.ToString();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Вводить только цифровые значения");
            }
            
        }

        private void Login(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(login.Text))
                User.Login = Convert.ToString(login.Text);
            else
            {
                if (!string.IsNullOrEmpty(User.Login))
                    login.Text = User.Login;
            }
        }

        private void Password(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(password.Text))
                User.Password = Convert.ToString(password.Text);
            else
            {
                if (!string.IsNullOrEmpty(User.Password))
                    password.Text = User.Password;
            }
        }

        private async void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           TableRowIndex = usersGrid.SelectedIndex;
        }

        private void DeleteUser(object sender, RoutedEventArgs e)
        {
            try
            {
                var res = vm.DeleteUser(usersGrid.SelectedItem);

                if (res != null)
                {
                    Users.RemoveAt(usersGrid.SelectedIndex);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Пользователь успешно удален");
            }
            
        }
    }
}