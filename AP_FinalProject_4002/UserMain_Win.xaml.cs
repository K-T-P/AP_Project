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
using System.Collections.ObjectModel;

namespace AP_FinalProject_4002
{
    /// <summary>
    /// Interaction logic for UserMain_Win.xaml
    /// </summary>
    public partial class UserMain_Win : Window
    {
        public User user { get; set; }
        public UserMain_Win(User user)
        {
            this.user = user;

            InitializeComponent();

            UserFnameTxt.Text = $"Welcome {user.FirstName}!";
            DataContext = user;
        }         
        public UserMain_Win()
        {

        }


        private void MainBtn_Click(object sender, RoutedEventArgs e)
        {
            tabtest.SelectedIndex = 0;
        }

        private void BookmarksBtn_Click(object sender, RoutedEventArgs e)
        {
            BookInfoReadOnly_Win book = new BookInfoReadOnly_Win();
            book.Show();
        }

        private void MyLibBtn_Click(object sender, RoutedEventArgs e)
        {
            tabtest.SelectedItem = MyLibTb;

        }

        private void MyProfBtn_Click(object sender, RoutedEventArgs e)
        {
            FNameTxtBx.Text = user.FirstName;
            LNameTxtBx.Text = user.LastName;
            PhoneNumTxtBx.Text = user.PhoneNum;
            EmailTxtBx.Text = user.Email;
            tabtest.SelectedItem = MyProfTb;

        }

        private void tabtest_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ProfileSaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (User.SignUp_fNameCheck(FNameTxtBx.Text)
                && User.SignUp_lNameCheck(LNameTxtBx.Text)
                && User.SignUp_PhoneNumberCheck(PhoneNumTxtBx.Text)
                && User.SignUp_EmailCheck(EmailTxtBx.Text))
            {
                if (EmailTxtBx.Text != user.Email && !User.SignUp_EmailExistsCheck(EmailTxtBx.Text))
                {
                    MessageBox.Show("Invalid Input!");
                }
                else
                {
                    user.FirstName = FNameTxtBx.Text;
                    user.LastName = LNameTxtBx.Text;
                    user.Email = EmailTxtBx.Text;
                    user.PhoneNum = PhoneNumTxtBx.Text;
                    MessageBox.Show("Profile Info Was Changed Successfully!");
                }
            }
            else
                MessageBox.Show("Invalid Input!");
        }

        private void LogoutBtn_Click(object sender, RoutedEventArgs e)
        {
            StartUpWin newStartup = new StartUpWin();
            newStartup.Show();
            this.Close();
        }

        private void TrialBtn_Click(object sender, RoutedEventArgs e)
        {
            UserSubscription_Win newsub = new UserSubscription_Win();
            newsub.Show();
        }

        private void WalletChargeBtn_Click(object sender, RoutedEventArgs e)
        {
            UserPay_Win newpay = new UserPay_Win();
            newpay.Show();
        }

        private void CartBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ChangePassBtn_Click(object sender, RoutedEventArgs e)
        {
            UserChangePass_Win newpass = new UserChangePass_Win();
            newpass.Show();
        }
    }
}
