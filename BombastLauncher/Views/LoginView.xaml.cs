using BombastLauncher.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BombastLauncher.Views
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : UserControl
    {
        AuthService AuthService;

        public LoginView()
        {
            AuthService = new AuthService();

            InitializeComponent();
        }

        private void createAccountLinkBtn_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://127.0.0.1/register");
        }

        private void forgotPasswordBtn_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://127.0.0.1/reset-password");
        }

        private void loginBtn_Click(object sender, RoutedEventArgs e)
        {
            var loginStatus = AuthService.TryLogin(emailTxt.Text, passwordTxt.Password);
        }
    }
}
