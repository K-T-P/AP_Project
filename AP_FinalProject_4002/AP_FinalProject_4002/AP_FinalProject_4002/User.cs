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
    class User: Person
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
        }

        long Balance { get; set; } = 0;

        public static void AutoLoad()
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\SKY\Desktop\AP_FinalProject_4002\UserServer\UserServer.mdf;Integrated Security=True;Connect Timeout=30");
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
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\SKY\Desktop\AP_FinalProject_4002\UserServer\UserServer.mdf;Integrated Security=True;Connect Timeout=30");
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
        public static bool SignUp_EmailExistsCheck(string email)
        {
            foreach (string key in users.Keys)
            {
                if (email.Equals(key))
                    return false;
            }
            return true;
        }
        public static bool SignUp_PasswordCheck(string password)
        {
            //string pattern = ""
            //Regex str = new Regex();
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
        public static bool SignUp_CVVCheck(string CVV)
        {
            string pattern = @"^\d{3,4}$";
            Regex rx = new Regex(pattern);
            Match m = rx.Match(CVV);
            if (m.Success)
                return true;
            else
                return false;
        }
        public static void WalletRecharge()
        {

        }
        
    }
}
