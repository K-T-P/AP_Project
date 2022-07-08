using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace AP_FinalProject_4002
{
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNum { get; set; }
        public static bool FirstNameCheck(string fName)
        {
            string pattern = @"^[a-zA-Z]{3,32}$";
            Regex rx = new Regex(pattern);
            Match m = rx.Match(fName);
            if (m.Success)
                return true;
            else
                return false;
        }
        public static bool LastNameCheck(string lName)
        {
            string pattern = @"^[a-zA-Z]{3,32}$";
            Regex rx = new Regex(pattern);
            Match m = rx.Match(lName);
            if (m.Success)
                return true;
            else
                return false;
        }

    }
}
