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
using System.Data.Entity.Core.Objects;

namespace AP_FinalProject_4002
{
    /// <summary>
    /// Interaction logic for UserMain_Win.xaml
    /// </summary>
    public partial class UserMain_Win : Window
    {
        public User user { get; set; }
        UserServerEntities userEntities = new UserServerEntities();
        BookServerEntities bookEntities = new BookServerEntities();
        public UserMain_Win(User user)
        {
            this.user = user;

            InitializeComponent();

            UserFnameTxt.Text = $"Welcome {user.FirstName}!";
            UserWalletTxt.Text = user.Balance.ToString();
            DataContext = user;
        }         


        private void MainBtn_Click(object sender, RoutedEventArgs e)
        {
            tabtest.SelectedItem = MainTb;
        }

        private void BookmarksBtn_Click(object sender, RoutedEventArgs e)
        {
            tabtest.SelectedItem = BookmarkTb;
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
            UserWalletRechargePrice_Win newRecharge = new UserWalletRechargePrice_Win(user);
            newRecharge.Show();
        }

        private void CartBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ChangePassBtn_Click(object sender, RoutedEventArgs e)
        {
            UserChangePass_Win newpass = new UserChangePass_Win();
            newpass.Show();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ObservableCollection<PDFBooksTable> AllBooks = new ObservableCollection<PDFBooksTable>();
            ObservableCollection<string> bookmarks = new ObservableCollection<string>();
            ObservableCollection<string> library = new ObservableCollection<string>();
            ObservableCollection<string> cart = new ObservableCollection<string>();

            var pdfbookQuery = from instance in bookEntities.PDFBooksTables
                            where (true)
                            select instance;
            var audiobookQuery = from instance in bookEntities.PDFBooksTables
                               where (true)
                               select instance;

            foreach (var instance in pdfbookQuery.ToList())
            {
                AllBooks.Add(instance);
            }

            foreach (var instance in audiobookQuery.ToList())
            {
                AllBooks.Add(instance);
            }
            
            AllBooksGrid.ItemsSource = AllBooks;

            PDFBookmarksGrid.ItemsSource = user.bookmarkedPDFBooks;
            AUdioBookmarksGrid.ItemsSource = user.bookmarkedAudioBooks;

            PDFBookLibGrid.ItemsSource = user.purchasedPDFBooks;
            AUdioBookLibGrid.ItemsSource = user.purchasedAudioBooks;

            PDFBookCartGrid.ItemsSource = user.PDFBooksInCart;
            AudioBookCartGrid.ItemsSource = user.AudioBooksInCart;
        }
    }
}
