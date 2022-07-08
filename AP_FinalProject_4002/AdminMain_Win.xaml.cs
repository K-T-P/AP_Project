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
    /// Interaction logic for AdminMain_Win.xaml
    /// </summary>
    public partial class AdminMain_Win : Window
    {
        public AdminMain_Win(Admin admin)
        {
            InitializeComponent();
            AdminFNameTxt.Text = $"Welcome, {admin.FirstName}!";
        }

        private void MainBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BooksLstBtn_Click(object sender, RoutedEventArgs e)
        {
            tabtest.SelectedItem = BooksLstTb;
            AdminBookInfoReadWrite_Win bookEdit = new AdminBookInfoReadWrite_Win();
            bookEdit.Show();
        }

        private void UsersLstBtn_Click(object sender, RoutedEventArgs e)
        {
            tabtest.SelectedItem = UsersLstTb;
            UserInfo_Win userinfo = new UserInfo_Win();
            userinfo.Show();
        }

        private void AdminLogoutBtn_Click(object sender, RoutedEventArgs e)
        {
            StartUpWin newStartup = new StartUpWin();
            newStartup.Show();
            this.Close();
        }

        private void VIPSttBtn_Click(object sender, RoutedEventArgs e)
        {
            AdminTrialEdit_Win newVIP = new AdminTrialEdit_Win();
            newVIP.Show();
        }
    }
}
