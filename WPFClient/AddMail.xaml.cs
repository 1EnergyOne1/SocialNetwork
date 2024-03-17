using Api.Data;
using Api.Data.Models;
using NodaTime;
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
    /// Логика взаимодействия для AddMail.xaml
    /// </summary>
    public partial class AddMail : Window
    {
        Mail mail = new Mail();
        UserVM userVM = new UserVM();
        MailsVM mailsVM = new MailsVM();
        List<User> Users = new List<User>();
        public int UserId { get; set; }

        public LocalDateTime DateSend { get; set; }

        public string? Message { get; set; }
        public AddMail()
        {
            InitializeComponent();
        }

        public AddMail(int toUserId)
        {
            InitializeComponent();
            mail.ToUserId = toUserId;
            getAllUsers();
            if (mail.Id != 0 || mail.Id != 1)
                getMailAsync();
        }

        private async void getAllUsers()
        {
            try
            {
                var res = await userVM.GetAllUsers();
                foreach (var DtoUser in res)
                {
                   var k = (User)DtoUser;
                   Users.Add(k);
                }
                toUsersComboBox.ItemsSource = Users.Select(x => x.Id);
                fromUsersComboBox.ItemsSource = Users.Select(x => x.Id);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Ошибка получения пользователей для создания нового письма");
            }
        }

        private async Task getMailAsync()
        {
            var res = await mailsVM.GetMail(mail.Id);
            if (res != null)
            {
                mail = (Mail)res;
            }
        }

        private void AddMessage(object sender, RoutedEventArgs e)
        {
            mail.Message = textMessage.Text;
            var res = mailsVM.AddMail(mail);
        }

        private void CloseWindow(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void selectedToUser(object sender, SelectionChangedEventArgs e)
        {
            mail.ToUserId = (Int32)toUsersComboBox.SelectedItem;
        }

        private void selectedFromUser(object sender, SelectionChangedEventArgs e)
        {
            mail.FromUserId = (Int32)fromUsersComboBox.SelectedItem;
        }
    }
}
