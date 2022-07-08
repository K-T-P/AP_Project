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
    /// Interaction logic for UserSignUp_Win1.xaml
    /// </summary>
    public partial class UserSignUp_Win1 : Window
    {
        public UserSignUp_Win1()
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

        private void UserSignUpNextBtn_Click(object sender, RoutedEventArgs e)
        {
            if (User.SignUp_fNameCheck(FristnameTxtBx.Text) && User.SignUp_lNameCheck(LastnameTxtBx.Text) && User.SignUp_PhoneNumberCheck(PhoneNumTxtBx.Text))
            {
                UserSignUp_Win2 nextSignUp = new UserSignUp_Win2(FristnameTxtBx.Text, LastnameTxtBx.Text, PhoneNumTxtBx.Text);
                nextSignUp.Show();
                this.Close();
            }
            else
                MessageBox.Show("Invalid Input!");
        }
    }
}
