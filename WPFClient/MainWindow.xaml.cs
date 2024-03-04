using Api.Data.Models;
using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using WPFClient.Interface;
using WPFClient.Service;
using WPFClient.vm;

namespace WPFClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        UserVM userVM = new UserVM();
        

        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void getAuthorization(object sender, RoutedEventArgs e)
        {
           var res = userVM.getAuthorizationAsync();
            if(res.Result == true)
            {
                this.Close();
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
