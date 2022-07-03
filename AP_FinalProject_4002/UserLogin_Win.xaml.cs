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
using System.Windows.Shapes;

namespace AP_FinalProject_4002
{
    /// <summary>
    /// Interaction logic for UserLogin_Win.xaml
    /// </summary>
    public partial class UserLogin_Win : Window
    {
        public UserLogin_Win()
        {
            InitializeComponent();
        }

        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void UserLoginBtn_Click(object sender, RoutedEventArgs e)
        {

        }


        private void ForgotMyPassBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            StartUpWin prevWin = new StartUpWin();
            prevWin.Show();
            this.Close();
        }

        private void AdminLoginBtn_Click(object sender, RoutedEventArgs e)
        {
            AdminLogin_Win newAdminLogin = new AdminLogin_Win();
            newAdminLogin.Show();
            this.Close();
        }

        private void UserSignUpBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
