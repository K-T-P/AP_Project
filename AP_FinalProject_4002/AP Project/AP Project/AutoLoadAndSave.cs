using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;
using System.IO;

namespace AP_Project
{
    static class AutoLoadAndSave
    {
        static public void AutoRegisterAdmin()
        {
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\SKY\Desktop\AP_Project\AP_Project\AdminServer\AdminServer.mdf;Integrated Security=True;Connect Timeout=30");
                string command = "select * from [AdminServer]";
                SqlCommand com = new SqlCommand(command, con);
                con.Open();
                SqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    string email = reader["email"].ToString();
                    string firstName = reader["firstName"].ToString();
                    string lastName = reader["lastName"].ToString();
                    string password = reader["password"].ToString();
                    int phoneNumber = int.Parse(reader["phoneNumber"].ToString());
                    AdminClass admin = new AdminClass();
                    AdminClass.adminGrp.Add(admin);
                }
                con.Close();
            }
            catch
            {

            }
            finally
            {
            }
        }
    }
}
