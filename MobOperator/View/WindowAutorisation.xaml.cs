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

namespace MobOperator
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class WindowAutorisation : Window
    {
        public WindowAutorisation()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // var registr = new Page1();
            NavigationWindow registr = new NavigationWindow();
            registr.Content = new Page1();
            registr.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var In = new MainWindow();
            this.Close();
            In.Show();
        }

        private void Button_ColorChanged(object sender, RoutedPropertyChangedEventArgs<Color> e)
        {

        }
    }
}
