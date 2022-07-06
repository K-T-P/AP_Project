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
    /// Interaction logic for AdminLogin_Win.xaml
    /// </summary>
    public partial class AdminLogin_Win : Window
    {
        public AdminLogin_Win()
        {
            InitializeComponent();
        }


        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            StartUpWin prevWin = new StartUpWin();
            prevWin.Show();
            this.Close();
        }

        private void ForgotMyPassBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AdminLoginBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
