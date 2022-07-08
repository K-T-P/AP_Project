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
    /// Interaction logic for AdminTrialEdit_Win.xaml
    /// </summary>
    public partial class AdminTrialEdit_Win : Window
    {
        public AdminTrialEdit_Win()
        {
            InitializeComponent();
        }
        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void TrialEditBtn_1_Click(object sender, RoutedEventArgs e)
        {
            Trial1.SelectedItem = TrialEditTb_1;
            Trial1.Visibility = Visibility.Visible;
            TrialEditTb_1.Visibility = Visibility.Visible;

        }

        private void TrialEditBtn_2_Click(object sender, RoutedEventArgs e)
        {
            Trial2.SelectedItem = TrialEditTb_2;
            Trial2.Visibility = Visibility.Visible;
            TrialEditTb_2.Visibility = Visibility.Visible;

        }

        private void Trial1EditBtn_3_Click(object sender, RoutedEventArgs e)
        {
            Trial3.SelectedItem = TrialEditTb_3;
            Trial3.Visibility = Visibility.Visible;
            TrialEditTb_3.Visibility = Visibility.Visible;

        }

        private void TrialFinalEditBtn_1_Click(object sender, RoutedEventArgs e)
        {
            //Save Changes
            Trial1.Visibility = Visibility.Hidden;
            TrialEditTb_1.Visibility = Visibility.Hidden;

        }

        private void TrialFinalEditBtn_2_Click(object sender, RoutedEventArgs e)
        {
            //Save Changes
            Trial2.Visibility = Visibility.Hidden;
            TrialEditTb_2.Visibility = Visibility.Hidden;

        }

        private void TrialFinalEditBtn_3_Click(object sender, RoutedEventArgs e)
        {
            Trial3.Visibility = Visibility.Hidden;
            TrialEditTb_3.Visibility = Visibility.Hidden;

        }
    }
}
