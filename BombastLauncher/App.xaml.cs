using BombastLauncher.Helpers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace BombastLauncher
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void OnStartup(object sender, StartupEventArgs e)
        {
            BombastSettings.BaseApiUrl = System.Configuration.ConfigurationManager.AppSettings["ApiUrl"];
            BombastSettings.ApiVersion = System.Configuration.ConfigurationManager.AppSettings["ApiVersion"];
            BombastSettings.ApiUrl = BombastSettings.BaseApiUrl + BombastSettings.ApiVersion + "/";

            ApplicationView app = new ApplicationView();
            ApplicationViewModel context = new ApplicationViewModel();
            app.DataContext = context;
            app.Show();
        }
    }
}
