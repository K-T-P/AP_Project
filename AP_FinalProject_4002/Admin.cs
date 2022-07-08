using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;

namespace AP_FinalProject_4002
{
    public class Admin : Person
    {
        static public ObservableCollection<Admin> adminGrp = new ObservableCollection<Admin>();

        static public void AutoSave()
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + AppDomain.CurrentDomain.BaseDirectory + @"AdminServer\AdminServer.mdf;Integrated Security=True;Connect Timeout=30");
            string command;
            con.Open();
            foreach (Admin admin in adminGrp)
            {
                command = "insert into [AdminTable] values('" + admin.Email.Trim() + "','" + admin.FirstName + "','" + admin.LastName + "','" + admin.Password + "','" + admin.PhoneNum + "')";
                SqlCommand com = new SqlCommand(command, con);
                com.ExecuteNonQuery();
            }
            con.Close();
        }

        static public void AutoLoad()
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + AppDomain.CurrentDomain.BaseDirectory + @"AdminServer\AdminServer.mdf;Integrated Security=True;Connect Timeout=30");
            string command = "select * from [AdminTable]";
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
                adminGrp.Add(new Admin(fName, lName, email, password, phoneNumber));
            }
            con.Close();
        }

        static public bool AdminEmailPasswordExistenceCheck(string email, string password)
        {
            try
            {
                var admin = adminGrp.Where(x => x.Email == email);
                if (admin.Count() == 1)
                {
                    Admin newAdmin = (Admin)admin;
                    if (newAdmin.Password == password)
                        return true;
                    else
                        return false;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
        public static Admin FindAdmin(string email)
        {
            var a = adminGrp.Where(x => x.Email == email);
            Admin admin = null;
            foreach (var instance in a)
                admin = instance;

            return admin;
        }

        public bool AddPDFBook(
            string pdfBookName,
            string authorFirstName,
            string authorLastName,
            string authorNationality,
            DateTime authorBirthDay,
            Gender authorGender,
            string authorBooks,
            string summary,
            string PDF_FileName,
            string photoPath,
            Type bookType,
            long cost,
            int point,
            int publishYear,
            long outcome,
            int numberOfSoldBooks,
            long monthlySubscriptionFee,
            DateTime offDate,
            long off
            )
        {
            string PDF_FileCompletePath = AppDomain.CurrentDomain.BaseDirectory + @"PDFBooksPDF_Files\" + PDF_FileName;
            if (!File.Exists(PDF_FileCompletePath))
                return false;
            string photoCompletePath = AppDomain.CurrentDomain.BaseDirectory + @"Pictures\" + photoPath;
            if (!File.Exists(photoCompletePath))
                return false;
            if (!FirstNameCheck(authorFirstName))
                return false;
            if (!LastNameCheck(authorLastName))
                return false;
            PDFBooks newPDFBook = new PDFBooks(pdfBookName, authorFirstName, authorLastName, authorNationality, authorBirthDay, authorGender, authorBooks, summary, PDF_FileName,
                photoPath, bookType, cost, point, publishYear, outcome, numberOfSoldBooks, monthlySubscriptionFee, off, offDate);
            PDFBooks.AddBookToGallery(newPDFBook);
            return true;
        }
        public bool AddAudioBook(
            string audioBookName,
            string authorFirstName,
            string authorLastName,
            string authorNationality,
            DateTime authorBirthDay,
            Gender authorGender,
            string authorBooks,
            string summary,
            string Audio_FileName,
            string photoPath,
            Type bookType,
            long cost,
            int point,
            int publishYear,
            long outcome,
            int numberOfSoldBooks,
            long monthlySubscriptionFee,
            DateTime offDate,
            long off
            )
        {
            string PDF_FileCompletePath = AppDomain.CurrentDomain.BaseDirectory + @"AudioBookMP3Files\" + Audio_FileName;
            if (!File.Exists(PDF_FileCompletePath))
                return false;
            string photoCompletePath = AppDomain.CurrentDomain.BaseDirectory + @"Pictures\" + photoPath;
            if (!File.Exists(photoCompletePath))
                return false;
            if (!FirstNameCheck(authorFirstName))
                return false;
            if (!LastNameCheck(authorLastName))
                return false;
            AudioBooks newAudioBook = new AudioBooks(audioBookName, authorFirstName, authorLastName, authorNationality, authorBirthDay, authorGender, authorBooks, summary, Audio_FileName,
                photoPath, bookType, cost, point, publishYear, outcome, numberOfSoldBooks, monthlySubscriptionFee, off, offDate);
            AudioBooks.AddBookToGallery(newAudioBook);
            return true;
        }
        public Admin(string firstName, string lastName, string email, string password, string phoneNumber)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Email = email;
            this.PhoneNum = phoneNumber;
            this.Password = password;
        }
    }
}
