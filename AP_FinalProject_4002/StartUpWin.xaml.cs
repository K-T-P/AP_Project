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

namespace AP_FinalProject_4002
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class StartUpWin : Window
    {
        public StartUpWin()
        {
            InitializeComponent();
        }

        private void UserLoginBtn_Click(object sender, RoutedEventArgs e)
        {
            var newWin = new UserLogin_Win();
            newWin.Show();
            this.Close();
        }

        private void UserSignUpBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AdminLoginBtn_Click(object sender, RoutedEventArgs e)
        {
            AdminLogin_Win newAdminLogin = new AdminLogin_Win();
            newAdminLogin.Show();
            this.Close();
        }

        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
