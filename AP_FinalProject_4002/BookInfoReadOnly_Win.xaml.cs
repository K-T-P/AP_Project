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
    /// Interaction logic for BookInfoReadOnly_Win.xaml
    /// </summary>
    public partial class BookInfoReadOnly_Win : Window
    {
        public BookInfoReadOnly_Win()
        {
            InitializeComponent();
        }

        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BuyBookBtn_Click(object sender, RoutedEventArgs e)
        {
            UserPay_Win pay = new UserPay_Win();
            pay.Show();

        }
    }
}
