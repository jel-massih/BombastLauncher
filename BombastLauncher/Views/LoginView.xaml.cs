﻿using System;
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
        public LoginView()
        {
            InitializeComponent();
        }

        private void createAccountLinkBtn_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://jel-massih.com/Bombast/get-bombastengine");
        }

        private void forgotPasswordBtn_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://jel-massih.com/Bombast/forgot-password");
        }
    }
}
