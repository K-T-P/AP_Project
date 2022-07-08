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
        public UserPay_Win()
        {
            InitializeComponent();
        }

        private void UserPayCancelBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
