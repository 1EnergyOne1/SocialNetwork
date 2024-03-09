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
        public UserPage()
        {
            InitializeComponent();
        }

        public UserPage(User user)
        {
            InitializeComponent();
            this.DataContext = user;
            User = user;
            UserName = user.Name;
            UserLastName = user.Lastname;
            UserLogin = user.Login;
            UserPassword = user.Password;
            UserAge = user.Age;
            GetAllUsers();
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
            User.Name = Convert.ToString(name.Text);
        }

        private void LastName(object sender, TextChangedEventArgs e)
        {
            User.Lastname = Convert.ToString(lastName.Text);
        }

        private void Age(object sender, TextChangedEventArgs e)
        {
            try
            {
                User.Age = Convert.ToInt32(age.Text);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Вводить только цифровые значения");
            }
            
        }

        private void Login(object sender, TextChangedEventArgs e)
        {
            User.Login = Convert.ToString(login.Text);
        }

        private void Password(object sender, TextChangedEventArgs e)
        {
            User.Password = Convert.ToString(password.Text);
        }

        private async void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }
    }
}