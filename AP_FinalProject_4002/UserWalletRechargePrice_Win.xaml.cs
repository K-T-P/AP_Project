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
    /// Interaction logic for UserWalletRechargePrice_Win.xaml
    /// </summary>
    public partial class UserWalletRechargePrice_Win : Window
    {
        public User user { get; set; }
        public UserWalletRechargePrice_Win(User user)
        {
            this.user = user;
            InitializeComponent();
        }

        private void UserPayCancelBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void UserRechargeBtn_Click(object sender, RoutedEventArgs e)
        {
            UserPay_Win newpay = new UserPay_Win(user, long.Parse(UserWalletRechargeTxtBx.Text));
            newpay.Show();
            this.Close();
        }
    }
}
