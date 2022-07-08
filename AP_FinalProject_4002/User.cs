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
        static Dictionary<string, string> users { get; set; } = new Dictionary<string, string>();

        static ObservableCollection<User> userGrp { get; set; } = new ObservableCollection<User>();

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

        long Balance { get; set; } = 0;

        public static void AutoLoad()
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + AppDomain.CurrentDomain.BaseDirectory.ToString() + @"UserServer\UserServer.mdf;Integrated Security=True;Connect Timeout=30");
            string command = "select * from [UserTable]";
            SqlCommand com = new SqlCommand(command, con);
            SqlDataReader reader = com.ExecuteReader();
            while (reader.Read())
            {
                string fName = reader["firstName"].ToString();
                string lName = reader["lastName"].ToString();
                string email = reader["email"].ToString();
                string password = reader["password"].ToString();
                string phoneNumber = reader["phoneNumber"].ToString();
                userGrp.Add(new User(fName, lName, email, password, phoneNumber));
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
                command = "insert into [UserTable] values('" + user.Email.Trim() + "','" + user.FirstName + "','" + user.LastName + "','" + user.PhoneNum + "','" + user.Password + "')";
                SqlCommand com = new SqlCommand(command, con);
                com.ExecuteNonQuery();
            }
            con.Close();
        }
        public static bool LogIn_TrueEmailPasswordCheck(string email, string password)
        {
            var a = userGrp.Where(x => x.Email == email);
            User user = null;
            foreach (var instance in a)
                user = instance;
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