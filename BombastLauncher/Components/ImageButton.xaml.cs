using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace BombastLauncher.Components
{
    public partial class ImageButton : UserControl
    {
        public static readonly DependencyProperty UpSourceProperty = DependencyProperty.RegisterAttached("UpSource", typeof(ImageSource), typeof(ImageButton));
        public static readonly DependencyProperty FocusSourceProperty = DependencyProperty.RegisterAttached("FocusSource", typeof(ImageSource), typeof(ImageButton));
        public static readonly DependencyProperty DownSourceProperty = DependencyProperty.RegisterAttached("DownSource", typeof(ImageSource), typeof(ImageButton));

        [Description("The image displayed when not focused."), Category("Common Properties")]
        public ImageSource UpSource
        {
            get { return base.GetValue(UpSourceProperty) as ImageSource; }
            set { base.SetValue(UpSourceProperty, value); }
        }

        [Description("The image displayed when focused."), Category("Common Properties")]
        public ImageSource FocusSource
        {
            get { return base.GetValue(FocusSourceProperty) as ImageSource; }
            set { base.SetValue(FocusSourceProperty, value); }
        }

        [Description("The image displayed when Pressed."), Category("Common Properties")]
        public ImageSource DownSource
        {
            get { return base.GetValue(DownSourceProperty) as ImageSource; }
            set { base.SetValue(DownSourceProperty, value); }
        }

        public ImageButton()
        {
            InitializeComponent();
        }

        private void Grid_MouseEnter(object sender, MouseEventArgs e)
        {
            image.Source = FocusSource;
        }

        private void Grid_MouseLeave(object sender, MouseEventArgs e)
        {
            image.Source = UpSource;
        }

        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            image.Source = DownSource;
        }

        private void Grid_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if(IsMouseOver)
            {
                image.Source = FocusSource;
            }
            else
            {
                image.Source = UpSource;
            }
        }
    }
}
