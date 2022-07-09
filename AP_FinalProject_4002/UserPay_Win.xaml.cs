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
    /// Interaction logic for UserPay_Win.xaml
    /// </summary>
    public partial class UserPay_Win : Window
    {
        public User user { get; set; }
        public long price { get; set; }
        public UserPay_Win(User user, long price)
        {
            this.user = user;
            this.price = price;
            InitializeComponent();
            PayPriceTxt.Text = $"{price}";
        }

        private void UserPayCancelBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void UserPayBtn_Click(object sender, RoutedEventArgs e)
        {
            string[] ExpDate = UserCardExpDateTxtBx.Text.Split(' ');
            if (User.CardNumber_Check(UserCardNmbrTxtBx.Text)
                && User.CardExpirationDate_Check(ExpDate[0], ExpDate[2])
                && User.CVVCheck(UserCardCVVTxtBx.Text)
                && UserCardPasswordBx.Password.ToString() == user.Password)
            {
                user.Balance += price;
                MessageBox.Show("Operation Successfull!");
                this.Close();
            }
            else
                MessageBox.Show("Invalid Input!");
        }
    }
}
