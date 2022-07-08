using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.IO;


namespace AP_FinalProject_4002
{
    public enum Type { vip, casual }
    public enum Gender { male, female }
    class PDFBooks
    {
        static public ObservableCollection<PDFBooks> pdfBookList = new ObservableCollection<PDFBooks>();
        static private int ID_Generator = 0;
        private int _ID { get; set; }
        public string Name { get; private set; }
        public string AuthorFirstName { get; private set; }
        public string AuthorLastName { get; private set; }
        public string AuthorNationality { get; private set; }
        public DateTime AuthorBirthDay { get; private set; }
        public Gender AuthorGender { get; private set; }
        public string AuthorBooks { get; private set; }
        public string Summary { get; private set; }
        public string PDF_FileName { get; private set; }
        public string PhotoPath { get; private set; }
        public Type bookType { get; private set; }
        public long Cost { get; private set; }
        public int Point { get; set; }
        public int PublishYear { get; private set; }
        public long Outcome { get; private set; }
        public int NumberOfSoldBooks { get; private set; }
        public long MonthlySubscriptionFee { get; private set; }
        //Takhfife zaman dar
        public DateTime OffDate { get; private set; }
        //megdare takhfif
        public long Off { get; private set; }

        static public void AutoLoad()
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + AppDomain.CurrentDomain.BaseDirectory.Trim() + @"BookServer\BookServer.mdf;Integrated Security=True;Connect Timeout=30");
            string command = "select * from [PDFBooksTable]";
            SqlCommand com = new SqlCommand(command, con);
            con.Open();
            SqlDataReader reader = com.ExecuteReader();
            while (reader.Read())
            {
                int ID = int.Parse(reader["ID"].ToString());
                PDFBooks.ID_Generator = int.Parse(reader["ID_Generator"].ToString());
                string name = reader["name"].ToString();
                string authorFirstName = reader["authorFirstName"].ToString();
                string authorLastName = reader["authorLastName"].ToString();
                string authorNationality = reader["authorNationality"].ToString();
                Gender authorGender;
                if (reader["authorGender"].ToString() == "true")
                    authorGender = Gender.male;
                else
                    authorGender = Gender.female;
                DateTime authorBirthDay;
                if (reader["authorBirthDay"] is DateTime)
                    authorBirthDay = (DateTime)reader["authorBirthDay"];
                else
                    authorBirthDay = DateTime.MinValue;
                string authorBooks = reader["authorBooks"].ToString();
                string summary = reader["summary"].ToString();
                string pdf_fileName = reader["PDF_FileName"].ToString();
                Type vip;
                if (reader["bookType"].ToString() == "true")
                    vip = Type.vip;
                else
                    vip = Type.casual;
                string photoPath = reader["photoPath"].ToString();
                long cost = long.Parse(reader["cost"].ToString());
                int point = int.Parse(reader["point"].ToString());
                int publishYear = int.Parse(reader["publishYear"].ToString());
                long outcome = long.Parse(reader["outcome"].ToString());
                int numberOfSoldBooks = int.Parse(reader["numberOfSoldBooks"].ToString());
                long monthlySubscriptionFee = long.Parse(reader["monthlySubscriptionFee"].ToString());
                DateTime d;
                if (reader["offTime"] is DateTime)
                    d = (DateTime)reader["offTime"];
                else
                    d = DateTime.MinValue;
                long off = long.Parse(reader["off"].ToString());
                PDFBooks pdfBook = new PDFBooks(ID,name, authorFirstName, authorLastName, authorNationality, authorBirthDay, authorGender, authorBooks, summary, pdf_fileName, photoPath, vip, cost, point, publishYear, outcome, numberOfSoldBooks, monthlySubscriptionFee, off, d);
                pdfBookList.Add(pdfBook);
            }
            con.Close();
        }
        static public void AutoSave()
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + AppDomain.CurrentDomain.BaseDirectory.Trim() + @"BookServer\BookServer.mdf;Integrated Security=True;Connect Timeout=30");
            string command;
            con.Open();
            command = "DELETE FROM [PDFBooksTable]";
            SqlCommand cmd = new SqlCommand(command, con);
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            foreach (PDFBooks pdfBook in pdfBookList)
            {
                command = "insert into [PDFBooksTable] values('" + pdfBook._ID + "','" + pdfBook.Name.Trim() + "','" + pdfBook.AuthorFirstName.Trim() + "','" + pdfBook.Cost + "','" + pdfBook.Summary.Trim()
                    + "','" + pdfBook.Point + "'";
                if (pdfBook.bookType == Type.vip)
                    command += ",'" + true + "'";
                else
                    command += ",'" + false + "'";
                command += ",'" + pdfBook.Off + "','" + pdfBook.OffDate + "','" + pdfBook.PhotoPath.Trim() + "','" + pdfBook.PDF_FileName.Trim() + "','" + pdfBook.PublishYear + "'" +
                    ",'" + pdfBook.Outcome + "','" + pdfBook.NumberOfSoldBooks + "','" + pdfBook.MonthlySubscriptionFee + "','" + pdfBook.AuthorBirthDay + "'";
                if (pdfBook.AuthorGender == Gender.male)
                    command += ",'" + true + "'";
                else
                    command += ",'" + false + "'";
                command += ",'" + pdfBook.AuthorBooks + "','" + pdfBook.AuthorNationality.Trim() + "','" + pdfBook.AuthorLastName.Trim() + "','"+PDFBooks.ID_Generator+"')";
                SqlCommand com = new SqlCommand(command, con);
                com.ExecuteNonQuery();
            }
            con.Close();
        }
        static public ObservableCollection<PDFBooks> SearchByBookName(string bookName)
        {
            ObservableCollection<PDFBooks> returnList = new ObservableCollection<PDFBooks>();
            foreach (PDFBooks book in pdfBookList.Where(book => book.Name.Contains(bookName)))
            {
                returnList.Add(book);
            }
            return returnList;
        }
        static public ObservableCollection<PDFBooks> SearchByAuthor(string author)
        {
            ObservableCollection<PDFBooks> returnList = new ObservableCollection<PDFBooks>();
            foreach (PDFBooks book in pdfBookList.Where(book => book.AuthorFirstName.Contains(author)))
            {
                returnList.Add(book);
            }
            return returnList;
        }
        static public void SetVip(int bookID, long monthlySubscriptionFee)
        {
            var searchResult = pdfBookList.Where(book => book._ID == bookID);
            if (searchResult.Count() == 1)
            {
                PDFBooks pdfBook = searchResult as PDFBooks;
                if (pdfBook != null)
                    pdfBook.MonthlySubscriptionFee = monthlySubscriptionFee;
            }
        }
        static public void SetOffDateAndOffCount(int bookID, long off, DateTime dateTime)
        {
            var searchResult = pdfBookList.Where(book => book._ID == bookID);
            if (searchResult.Count() == 1)
            {
                PDFBooks pdfBook = searchResult as PDFBooks;
                if (pdfBook != null)
                {
                    pdfBook.Off = off;
                    pdfBook.OffDate = dateTime;
                }
            }
        }
        static public string ViewOutCome(int bookID)
        {
            var searchResult = pdfBookList.Where(book => book._ID == bookID);
            if (searchResult.Count() == 1)
            {
                PDFBooks pdfBook = searchResult as PDFBooks;
                if (pdfBook != null)
                    return "OutCome : " + pdfBook.Outcome.ToString() + "\nNumber Of Sold Books : " + pdfBook.NumberOfSoldBooks;
                else
                    return "Entered Book Was Not Found!";
            }
            else
            {
                return "Entered Book Was Not Found!";
            }
        }
        static public int ViewPoint(int bookID)
        {
            var searchResult = pdfBookList.Where(book => book._ID == bookID);
            if (searchResult.Count() == 1)
            {
                PDFBooks pdfBook = searchResult as PDFBooks;
                if (pdfBook != null)
                    return pdfBook.Point;
                else
                    return -1;
            }
            else
                return -1;
        }
        static public void UpdateOffDates()
        {
            var resultList = PDFBooks.pdfBookList
                  .Where(book => book.Off != 0)
                  .Where((PDFBooks book) => { int res = DateTime.Compare(DateTime.Now, book.OffDate); if (res >= 0) return true; else return false; });

            foreach (var book in resultList)
            {
                PDFBooks pdfBook = book as PDFBooks;
                if (pdfBook != null)
                    pdfBook.Off = 0;
            }
        }
        static public void ChangeBookName(int bookID, string newName)
        {
            var searchResult = pdfBookList.Where(book => book._ID == bookID);
            if (searchResult.Count() == 1)
            {
                PDFBooks pdfBook = searchResult as PDFBooks;
                if (pdfBook != null)
                    pdfBook.Name = newName;
            }
        }
        static public void ChangeAuthorFirstName(int bookID, string newAuthorFirstName)
        {
            var searchResult = pdfBookList.Where(book => book._ID == bookID);
            if (searchResult.Count() == 1)
            {
                PDFBooks pdfBook = searchResult as PDFBooks;
                if (pdfBook != null)
                    pdfBook.AuthorFirstName = newAuthorFirstName;
            }
        }
        static public void ChangeAuthorLastName(int bookID, string newAuthorLastName)
        {
            var searchResult = pdfBookList.Where(book => book._ID == bookID);
            if (searchResult.Count() == 1)
            {
                PDFBooks pdfBook = searchResult as PDFBooks;
                if (pdfBook != null)
                    pdfBook.AuthorLastName = newAuthorLastName;
            }
        }
        static public void ChangeAuthorNationality(int bookID, string authorNewNationality)
        {
            var searchResult = pdfBookList.Where(book => book._ID == bookID);
            if (searchResult.Count() == 1)
            {
                PDFBooks pdfBook = searchResult as PDFBooks;
                if (pdfBook != null)
                    pdfBook.AuthorNationality = authorNewNationality;
            }
        }
        static public void ChangeAuthorBirthDay(int bookID, DateTime newBirthDay)
        {
            var searchResult = pdfBookList.Where(book => book._ID == bookID);
            if (searchResult.Count() == 1)
            {
                PDFBooks pdfBook = searchResult as PDFBooks;
                if (pdfBook != null)
                    pdfBook.AuthorBirthDay = newBirthDay;
            }
        }
        static public void ChangeAuthorGender(int bookID, Gender authorNewGender)
        {
            var searchResult = pdfBookList.Where(book => book._ID == bookID);
            if (searchResult.Count() == 1)
            {
                PDFBooks pdfBook = searchResult as PDFBooks;
                if (pdfBook != null)
                    pdfBook.AuthorGender = authorNewGender;
            }
        }
        static public void ChangeAuthorBooks(int bookID, string authorNewBooks)
        {
            var searchResult = pdfBookList.Where(book => book._ID == bookID);
            if (searchResult.Count() == 1)
            {
                PDFBooks pdfBook = searchResult as PDFBooks;
                if (pdfBook != null)
                    pdfBook.AuthorBooks = authorNewBooks;
            }
        }
        static public void ChangeSummary(int bookID, string newSummary)
        {
            var searchResult = pdfBookList.Where(book => book._ID == bookID);
            if (searchResult.Count() == 1)
            {
                PDFBooks pdfBook = searchResult as PDFBooks;
                if (pdfBook != null)
                    pdfBook.Summary = newSummary;
            }
        }
        static public void ChangePdfFileName(int bookID, string newPdfFileName)
        {
            var searchResult = pdfBookList.Where(book => book._ID == bookID);
            if (searchResult.Count() == 1)
            {
                PDFBooks pdfBook = searchResult as PDFBooks;
                if (pdfBook != null)
                    pdfBook.PDF_FileName = newPdfFileName;
            }
        }
        static public void ChangePhotoName(int bookID, string newPhotoName)
        {
            var searchResult = pdfBookList.Where(book => book._ID == bookID);
            if (searchResult.Count() == 1)
            {
                PDFBooks pdfBook = searchResult as PDFBooks;
                if (pdfBook != null)
                    pdfBook.PhotoPath = newPhotoName;
            }
        }
        static public void ChangeTypeToFree(int bookID)
        {
            var searchResult = pdfBookList.Where(book => book._ID == bookID);
            if (searchResult.Count() == 1)
            {
                PDFBooks pdfBook = searchResult as PDFBooks;
                if (pdfBook != null)
                {
                    pdfBook.bookType = Type.casual;
                    pdfBook.MonthlySubscriptionFee = 0;
                }
            }
        }
        static public void ChangeCost(int bookID, long newCost)
        {
            var searchResult = pdfBookList.Where(book => book._ID == bookID);
            if (searchResult.Count() == 1)
            {
                PDFBooks pdfBook = searchResult as PDFBooks;
                if (pdfBook != null)
                    pdfBook.Cost = newCost;
            }
        }
        static public void ChangePoint(int bookID, int newPoint)
        {
            var searchResult = pdfBookList.Where(book => book._ID == bookID);
            if (searchResult.Count() == 1)
            {
                PDFBooks pdfBook = searchResult as PDFBooks;
                if (pdfBook != null)
                    pdfBook.Point = newPoint;
            }
        }
        static public void ChangePublishYear(int bookID, int newPublishYear)
        {
            var searchResult = pdfBookList.Where(book => book._ID == bookID);
            if (searchResult.Count() == 1)
            {
                PDFBooks pdfBook = searchResult as PDFBooks;
                if (pdfBook != null)
                    pdfBook.PublishYear = newPublishYear;
            }
        }
        static public void AddBookToGallery(PDFBooks newPDFBook)
        {
            PDFBooks.pdfBookList.Add(newPDFBook);
        }
        static public void OpenPDFBook(int bookID)
        {
            var searchResult = pdfBookList.Where(book => book._ID == bookID);
            if (searchResult.Count() == 1)
            {
                PDFBooks pdfBook = searchResult as PDFBooks;
                if (pdfBook != null)
                {
                    string File_Name = pdfBook.PDF_FileName;
                    var process = new System.Diagnostics.Process();
                    process.StartInfo = new System.Diagnostics.ProcessStartInfo(File_Name)
                    {
                        UseShellExecute = true
                    };
                    process.Start();
                }
            }
        }
        public PDFBooks(
            string name,
            string authorFirstName,
            string authorLastName,
            string authorNationality,
            DateTime authorBirthDay,
            Gender authorGender,
            string authorBooks,
            string summary,
            string pdfFileName,
            string photoPath,
            Type type,
            long cost,
            int point,
            int publishYear,
            long outcome,
            int numberOfSoldBooks,
            long monthlySubscriptionFee,
            long off,
            DateTime offTime)
        {
            PDFBooks.ID_Generator++;
            this._ID = ID_Generator;
            this.Name = name;
            this.AuthorFirstName = authorFirstName;
            this.AuthorLastName = authorLastName;
            this.AuthorNationality = authorNationality;
            this.AuthorGender = authorGender;
            this.AuthorBirthDay = authorBirthDay;
            this.AuthorBooks = authorBooks;
            this.Summary = summary;
            this.PDF_FileName = pdfFileName;
            this.PhotoPath = photoPath;
            this.bookType = type;
            this.Cost = cost;
            this.Point = point;
            this.PublishYear = publishYear;
            this.Outcome = outcome;
            this.NumberOfSoldBooks = numberOfSoldBooks;
            this.MonthlySubscriptionFee = monthlySubscriptionFee;
            this.OffDate = offTime;
            this.Off = off;
        }
        public PDFBooks(
            int Id,
            string name,
            string authorFirstName,
            string authorLastName,
            string authorNationality,
            DateTime authorBirthDay,
            Gender authorGender,
            string authorBooks,
            string summary,
            string pdfFileName,
            string photoPath,
            Type type,
            long cost,
            int point,
            int publishYear,
            long outcome,
            int numberOfSoldBooks,
            long monthlySubscriptionFee,
            long off,
            DateTime offTime)
        {
            this._ID = Id;
            this.Name = name;
            this.AuthorFirstName = authorFirstName;
            this.AuthorLastName = authorLastName;
            this.AuthorNationality = authorNationality;
            this.AuthorGender = authorGender;
            this.AuthorBirthDay = authorBirthDay;
            this.AuthorBooks = authorBooks;
            this.Summary = summary;
            this.PDF_FileName = pdfFileName;
            this.PhotoPath = photoPath;
            this.bookType = type;
            this.Cost = cost;
            this.Point = point;
            this.PublishYear = publishYear;
            this.Outcome = outcome;
            this.NumberOfSoldBooks = numberOfSoldBooks;
            this.MonthlySubscriptionFee = monthlySubscriptionFee;
            this.OffDate = offTime;
            this.Off = off;
        }
    }
}
