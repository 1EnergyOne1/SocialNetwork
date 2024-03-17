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
        public int UserId { get; set; }

        public Instant DateSend { get; set; }

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

        private void getAllUsers()
        {
            usersComboBox.ItemsSource = (System.Collections.IEnumerable)userVM.GetAllUsers();
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

        private void selectedUser(object sender, SelectionChangedEventArgs e)
        {
            var item = usersComboBox.SelectedItem;
        }
    }
}
