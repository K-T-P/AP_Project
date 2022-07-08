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
    /// Interaction logic for UserSignUp_Win2.xaml
    /// </summary>
    public partial class UserSignUp_Win2 : Window
    {
        string Firstname { get; set; }
        string Lastname { get; set; }
        string PhoneNum { get; set; }
        public UserSignUp_Win2(string firstname, string lastname, string phoneNum)
        {
            Firstname = firstname;
            Lastname = lastname;
            PhoneNum = phoneNum;
            InitializeComponent();
        }

        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            UserSignUp_Win1 prevSignUp = new UserSignUp_Win1();
            prevSignUp.Show();
            this.Close();
        }

        private void FinalUserSignUpNextBtn_Click(object sender, RoutedEventArgs e)
        {
            if (User.SignUp_EmailCheck(EmailTxtBx.Text)
                && User.SignUp_EmailExistsCheck(EmailTxtBx.Text)
                && User.SignUp_PasswordFormatCheck(PassBx.Password.ToString())
                && PassBx.Password.ToString() == RptPassBx.Password.ToString())
            {
                User newUser = new User(Firstname, Lastname, EmailTxtBx.Text, PassBx.Password.ToString(), PhoneNum);
                UserLogin_Win newLogin = new UserLogin_Win();
                newLogin.Show();
                this.Close();
            }
            else
                MessageBox.Show("Invalid Input!");
        }
    }
}
