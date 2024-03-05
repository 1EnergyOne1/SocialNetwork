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
    /// Логика взаимодействия для AddUser.xaml
    /// </summary>
    public partial class AddUser : Window
    {
        public AddUser()
        {
            InitializeComponent();
        }

        UserVM userVM = new UserVM();

        private async void addUser(object sender, RoutedEventArgs e)
        {
            var res = await userVM.AddUser();
            if (res != null)
            {
                MessageBox.Show("Пользователь добавлен");                
            }
            else
            {
                MessageBox.Show("Ошибка добавления пользователя");
            }
        }

        private void Login(object sender, TextChangedEventArgs e)
        {
            userVM.Login = Convert.ToString(log.Text);
        }

        private void Password(object sender, TextChangedEventArgs e)
        {
            userVM.Password = Convert.ToString(pass.Text);
        }
    }
}
