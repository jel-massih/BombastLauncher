using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BombastLauncher.Models
{
    class BaseLauncherViewModel : IPageViewModel
    {
        public string Name
        {
            get
            {
                return "Base Launcher";
            }
        }
    }
}
