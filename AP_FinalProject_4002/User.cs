using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
//using Microsoft.Data.SqlClient;
using System.IO;
using System.Collections.ObjectModel;

namespace AP_FinalProject_4002
{
    public class User : Person
    {
        static public Dictionary<string, string> users { get; set; } = new Dictionary<string, string>();

        static public ObservableCollection<User> userGrp { get; set; } = new ObservableCollection<User>();

        public ObservableCollection<PDFBooks> purchasedPDFBooks = new ObservableCollection<PDFBooks>();

        public ObservableCollection<PDFBooks> bookmarkedPDFBooks = new ObservableCollection<PDFBooks>();

        public ObservableCollection<PDFBooks> PDFBooksInCart = new ObservableCollection<PDFBooks>();

        public ObservableCollection<AudioBooks> purchasedAudioBooks = new ObservableCollection<AudioBooks>();

        public ObservableCollection<AudioBooks> bookmarkedAudioBooks = new ObservableCollection<AudioBooks>();

        public ObservableCollection<AudioBooks> AudioBooksInCart = new ObservableCollection<AudioBooks>();
        public long Balance { get; set; }

        public User(string fname, string lname, string email, string password, string phone)
        {
            FirstName = fname;
            LastName = lname;
            Email = email;
            Password = password;
            PhoneNum = phone;
            users.Add(Email, Password);
            userGrp.Add(this);
        }


        public static void AutoLoad()
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + AppDomain.CurrentDomain.BaseDirectory.ToString() + @"UserServer\UserServer.mdf;Integrated Security=True;Connect Timeout=30");
            string command = "select * from [UserTable]";
            SqlCommand com = new SqlCommand(command, con);
            con.Open();
            SqlDataReader reader = com.ExecuteReader();
            while (reader.Read())
            {
                string fName = reader["firstName"].ToString();
                string lName = reader["lastName"].ToString();
                string email = reader["email"].ToString();
                string password = reader["password"].ToString();
                string phoneNumber = reader["phoneNumber"].ToString();
                string[] purchasedAudioBooks = reader["purchasedAudioBooks"].ToString().Split('a');
                string[] purchaasedPDFBooks = reader["purchasedPDFBooks"].ToString().Split('a');
                string[] bookmarkedAudioBooks = reader["bookmarkedAudioBooks"].ToString().Split('a');
                string[] bookmarkedPDFBooks = reader["bookmarkedPDFBooks"].ToString().Split('a');
                string[] PDFBooksInCart = reader["cartPDFBooks"].ToString().Split('a');
                string[] AudioBooksInCart = reader["cartAudioBooks"].ToString().Split('a');
                User newUser = new User(fName, lName, email, password, phoneNumber);
                userGrp.Add(newUser);

                if (purchasedAudioBooks[0] != "-1")
                {
                    foreach (string id in purchasedAudioBooks)
                    {
                        AudioBooks audioBook = null;
                        var a = AudioBooks.AudioBooksList.Where(x => x._ID == int.Parse(id));
                        foreach (var b in a)
                            audioBook = b as AudioBooks;
                        if (audioBook != null)
                            newUser.purchasedAudioBooks.Add(audioBook);
                    }
                }
                if (purchaasedPDFBooks[0] != "-1")
                {
                    foreach (string id in purchaasedPDFBooks)
                    {
                        PDFBooks pdfBook = null;
                        var a = PDFBooks.pdfBookList.Where(x => x._ID == int.Parse(id));
                        foreach (var b in a)
                            pdfBook = b as PDFBooks;
                        if (pdfBook != null)
                            newUser.purchasedPDFBooks.Add(pdfBook);
                    }
                }
                if (bookmarkedAudioBooks[0] != "-1")
                {
                    foreach (string id in bookmarkedAudioBooks)
                    {
                        AudioBooks audioBook = null;
                        var a = AudioBooks.AudioBooksList.Where(x => x._ID == int.Parse(id));
                        foreach (var b in a)
                            audioBook = b as AudioBooks;
                        if (audioBook != null)
                            newUser.bookmarkedAudioBooks.Add(audioBook);
                    }
                }
                if (bookmarkedPDFBooks[0] != "-1")
                {
                    foreach (string id in bookmarkedPDFBooks)
                    {
                        PDFBooks pdfBook = null;
                        var a = PDFBooks.pdfBookList.Where(x => x._ID == int.Parse(id));
                        foreach (var b in a)
                            pdfBook = b as PDFBooks;
                        if (pdfBook != null)
                            newUser.bookmarkedPDFBooks.Add(pdfBook);
                    }
                }
                if (AudioBooksInCart[0] != "-1")
                {
                    foreach (string id in AudioBooksInCart)
                    {
                        AudioBooks audioBook = null;
                        var a = AudioBooks.AudioBooksList.Where(x => x._ID == int.Parse(id));
                        foreach (var b in a)
                            audioBook = b as AudioBooks;
                        if (audioBook != null)
                            newUser.AudioBooksInCart.Add(audioBook);
                    }
                }
                if (PDFBooksInCart[0] != "-1")
                {
                    foreach (string id in PDFBooksInCart)
                    {
                        PDFBooks pdfBook = null;
                        var a = PDFBooks.pdfBookList.Where(x => x._ID == int.Parse(id));
                        foreach (var b in a)
                            pdfBook = b as PDFBooks;
                        if (pdfBook != null)
                            newUser.PDFBooksInCart.Add(pdfBook);
                    }
                }
                users.Add(email, password);
            }
            con.Close();
        }
        public static void AutoSave()
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + AppDomain.CurrentDomain.BaseDirectory + @"UserServer\UserServer.mdf;Integrated Security=True;Connect Timeout=30");
            string command;
            con.Open();
            foreach (User user in User.userGrp)
            {
                string purchasedAudioBooksString = "";
                if (user.purchasedAudioBooks.Count != 0)
                {
                    for (int i = 0; i < user.purchasedAudioBooks.Count - 1; i++)
                    {
                        if (user.purchasedAudioBooks[i] != null)
                            purchasedAudioBooksString += (user.purchasedAudioBooks[i]._ID + 'a');
                    }
                    purchasedAudioBooksString += user.purchasedAudioBooks[user.purchasedAudioBooks.Count - 1];
                }
                else
                {
                    purchasedAudioBooksString = "-1";
                }

                string purchasedPDFBooksString = "";
                if (user.purchasedPDFBooks.Count != 0)
                {
                    for (int i = 0; i < user.purchasedPDFBooks.Count - 1; i++)
                    {
                        if (user.purchasedPDFBooks[i] != null)
                            purchasedPDFBooksString += (user.purchasedPDFBooks[i]._ID + 'a');
                    }
                    purchasedPDFBooksString += user.purchasedPDFBooks[user.purchasedPDFBooks.Count - 1];
                }
                else
                {
                    purchasedPDFBooksString = "-1";
                }

                string bookmarkedAudioBooksString = "";
                if (user.bookmarkedAudioBooks.Count != 0)
                {
                    for (int i = 0; i < user.bookmarkedAudioBooks.Count - 1; i++)
                    {
                        if (user.bookmarkedAudioBooks[i] != null)
                            bookmarkedAudioBooksString += (user.bookmarkedAudioBooks[i]._ID + 'a');
                    }
                    bookmarkedAudioBooksString += user.bookmarkedAudioBooks[user.bookmarkedAudioBooks.Count - 1];
                }
                else
                {
                    bookmarkedAudioBooksString = "-1";
                }

                string bookmarkedPDFBooksString = "";
                if (user.bookmarkedPDFBooks.Count != 0)
                {
                    for (int i = 0; i < user.bookmarkedPDFBooks.Count - 1; i++)
                    {
                        if (user.bookmarkedPDFBooks[i] != null)
                            bookmarkedPDFBooksString += (user.bookmarkedPDFBooks[i]._ID + 'a');
                    }
                    bookmarkedPDFBooksString += user.bookmarkedPDFBooks[user.bookmarkedPDFBooks.Count - 1];
                }
                else
                {
                    bookmarkedPDFBooksString = "-1";
                }

                string PDFBooksInCartString = "";
                if (user.PDFBooksInCart.Count != 0)
                {
                    for (int i = 0; i < user.PDFBooksInCart.Count - 1; i++)
                    {
                        if (user.PDFBooksInCart[i] != null)
                            PDFBooksInCartString += (user.PDFBooksInCart[i]._ID + 'a');
                    }
                    PDFBooksInCartString += user.PDFBooksInCart[user.PDFBooksInCart.Count - 1];
                }
                else
                {
                    PDFBooksInCartString = "-1";
                }

                string AudioBooksInCartString = "";
                if (user.AudioBooksInCart.Count != 0)
                {
                    for (int i = 0; i < user.AudioBooksInCart.Count - 1; i++)
                    {
                        if (user.AudioBooksInCart[i] != null)
                            AudioBooksInCartString += (user.AudioBooksInCart[i]._ID + 'a');
                    }
                    AudioBooksInCartString += user.AudioBooksInCart[user.AudioBooksInCart.Count - 1];
                }
                else
                {
                    AudioBooksInCartString += "-1";
                }

                command = "insert into [UserTable] values('" + user.Email.Trim() + "','" + user.FirstName + "','" +
                    user.LastName + "','" + user.PhoneNum + "','" + user.Password + "','" + purchasedAudioBooksString.Trim() + "','" + purchasedPDFBooksString.Trim() + "'" +
                    ",'" + bookmarkedAudioBooksString.Trim() + "','" + bookmarkedPDFBooksString.Trim() + "','" + PDFBooksInCartString.Trim() + "','" + AudioBooksInCartString.Trim() + "')";
                SqlCommand com = new SqlCommand(command, con);
                com.ExecuteNonQuery();
            }
            con.Close();
        }
        public static bool LogIn_TrueEmailPasswordCheck(string email, string password)
        {
            var a = userGrp.Where(x => x.Email == email);
            User user = null;
            foreach (var varUser in a)
            {
                user = (User)varUser;
            }
            if (user.Password == password)
                return true;
            else
                return false;
        }
        public static User FindUser(string email)
        {
            var a = userGrp.Where(x => x.Email == email);
            User user = null;
            foreach (var instance in a)
                user = instance;
            return user;
        }
        public static bool SignUp_EmailExistsCheck(string email)
        {
            foreach (string key in users.Keys)
            {
                if (email.Equals(key))
                    return false;
            }
            return true;
        }
        public static bool SignUp_PasswordFormatCheck(string password)
        {
            Regex rx = new Regex("^.{8,40}$");
            Match m = rx.Match(password);
            if (m.Success)
            {
                rx = new Regex("(^.*[a-z].*[A-Z].*$)|(^.*[A-Z].*[a-z].*$)");
                m = rx.Match(password);
                if (m.Success)
                    return true;
                else
                    return false;
            }
            else
                return false;
        }
        public static bool SignUp_PhoneNumberCheck(string phoneNumber)
        {
            string pattern = @"^09\d{9}$";
            Regex rx = new Regex(pattern);
            Match m = rx.Match(phoneNumber);
            if (m.Success)
                return true;
            else
                return false;
        }
        public static bool SignUp_EmailFormatCheck(string email)
        {
            string pattern = @"^\w{3,32}\@\w{3,32}\.\w{3,32}$";
            Regex rx = new Regex(pattern);
            Match m = rx.Match(email);
            if (m.Success)
                return true;
            else
                return false;
        }
        public static bool SignUp_fNameCheck(string fName)
        {
            string pattern = @"^[a-zA-Z]{3,32}$";
            Regex rx = new Regex(pattern);
            Match m = rx.Match(fName);
            if (m.Success)
                return true;
            else
                return false;
        }
        public static bool SignUp_lNameCheck(string lName)
        {
            string pattern = @"^[a-zA-Z]{3,32}$";
            Regex rx = new Regex(pattern);
            Match m = rx.Match(lName);
            if (m.Success)
                return true;
            else
                return false;
        }
        public static bool SignUp_EmailCheck(string email)
        {
            string pattern = @"^\w{3,32}\@\w{3,32}\.\w{3,32}$";
            Regex rx = new Regex(pattern);
            Match m = rx.Match(email);
            if (m.Success)
                return true;
            else
                return false;
        }

        public static bool CVVCheck(string CVV)
        {
            string pattern = @"^\d{3,4}$";
            Regex rx = new Regex(pattern);
            Match m = rx.Match(CVV);
            if (m.Success)
                return true;
            else
                return false;
        }
        public static bool CardNumber_Check(string cardNumber)
        {
            int num = 0;
            for (int i = cardNumber.Length - 1; i >= 0; i--)
            {
                int a = (int)cardNumber[i] - 48;
                if ((i + 1) % 2 == 0)
                    a *= 2;
                if (a >= 10)
                    num += (a / 10 + a % 10);
                else
                    num += a;
            }

            if (num % 10 == 0)
                return true;
            else
                return false;
        }
        public static bool CardExpirationDate_Check(string year, string month)
        {
            int yearInt = int.Parse(year);
            int monthInt = int.Parse(month);
            if (monthInt < 10)
                yearInt += 621;
            else
                yearInt += 622;
            monthInt = ((monthInt + 1) % 12) + 1;
            DateTime d1 = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 0);
            DateTime d2 = new DateTime(yearInt, monthInt, 0);
            int res = DateTime.Compare(d1, d2);
            if (res < 0)
                return true;
            else
                return false;
        }
        public static void WalletRecharge()
        {

        }

    }
}
