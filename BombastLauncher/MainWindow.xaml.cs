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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BombastLauncher
{
    public partial class MainWindow : Window
    {
        private bool m_restoreForDragMove;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void titleBar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if(e.ClickCount == 2)
            {
                if(WindowState == WindowState.Normal)
                {
                    WindowState = WindowState.Maximized;
                }
                else
                {
                    WindowState = WindowState.Normal;
                }
            }
            else
            {
                m_restoreForDragMove = WindowState == WindowState.Maximized;
                DragMove();
            }
        }

        private void titleBar_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            m_restoreForDragMove = false;
        }

        private void titleBar_MouseMove(object sender, MouseEventArgs e)
        {
            if(m_restoreForDragMove)
            {
                m_restoreForDragMove = false;

                var point = PointToScreen(e.MouseDevice.GetPosition(this));

                Left = point.X - (RestoreBounds.Width * 0.5);
                Top = point.Y;

                WindowState = WindowState.Normal;
                DragMove();
            }
        }

    }
}
