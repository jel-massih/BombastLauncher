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
    public partial class FancyPasswordBox : UserControl
    {
        public static readonly DependencyProperty PlaceholderTextForegroundBrushProperty = DependencyProperty.RegisterAttached("PlaceholderTextForegroundBrush", typeof(Brush), typeof(FancyPasswordBox), new PropertyMetadata((SolidColorBrush)(new BrushConverter().ConvertFrom("#6f6f6f"))));
        public static readonly DependencyProperty TextForegroundBrushProperty = DependencyProperty.RegisterAttached("TextForegroundBrush", typeof(Brush), typeof(FancyPasswordBox), new PropertyMetadata((SolidColorBrush)(new BrushConverter().ConvertFrom("#cccccc"))));

        public static readonly DependencyProperty PlaceholderTextProperty = DependencyProperty.RegisterAttached("PlaceholderText", typeof(string), typeof(FancyPasswordBox));

        [Description("The foreground brush to be used within the textbox."), Category("Brush")]
        public Brush TextForegroundBrush
        {
            get { return base.GetValue(TextForegroundBrushProperty) as Brush; }
            set { base.SetValue(TextForegroundBrushProperty, value); }
        }

        [Description("The foreground brush to be used within the textbox for placeholder text."), Category("Brush")]
        public Brush PlaceholderTextForegroundBrush
        {
            get { return base.GetValue(PlaceholderTextForegroundBrushProperty) as Brush; }
            set { base.SetValue(PlaceholderTextForegroundBrushProperty, value); }
        }

        [Description("The placeholder text to show when textbox is empty."), Category("Common")]
        public string PlaceholderText
        {
            get { return base.GetValue(PlaceholderTextForegroundBrushProperty) as string; }
            set { base.SetValue(PlaceholderTextForegroundBrushProperty, value); }
        }

        public string Password
        {
            get { return textbox.Password; }
        }

        public FancyPasswordBox()
        {
            InitializeComponent();
        }

        private void textbox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(textbox.Password))
            {
                placeholder_txtBlock.Visibility = Visibility.Hidden;
            }
            else
            {
                placeholder_txtBlock.Visibility = Visibility.Visible;
            }
        }
    }
}
