using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;

namespace AP_Project
{
    class AdminClass
    {
        static public ObservableCollection<AdminClass> adminGrp { get; set; }
        public AdminClass(
            string f_Name,
            string l_Name,
            string email,
            string password,
            int p_Number)
        {

        }
    }
}
