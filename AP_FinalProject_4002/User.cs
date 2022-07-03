using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AP_FinalProject_4002
{
    class User: Person
    {
        static Dictionary<string, string> users { get; set; } = new Dictionary<string, string>();

        public User(string fname, string lname, string email, string password, int phone)
        {
            FirstName = fname;
            LastName = lname;
            Email = email;
            Password = password;
            PhoneNum = phone;
            users.Add(Email, Password);
        }

        long Balance { get; set; } = 0;
    
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

        public static void WalletRecharge()
        {

        }
        
    }
}
