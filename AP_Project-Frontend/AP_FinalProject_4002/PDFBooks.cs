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
    enum Type { vip, casual }
    enum Gender { male, female }
    class PDFBooks
    {
        static public ObservableCollection<PDFBooks> pdfBookList = new ObservableCollection<PDFBooks>();

        private int _ID { get; set; }
        public string Name { get; private set; }
        public string AuthorName { get; private set; }
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
                string name = reader["name"].ToString();
                string authorName = reader["authorName"].ToString();
                string authorNationality = reader["authorNationality"].ToString();
                Gender authorGender;
                if (reader["authorGender"].ToString() == "true")
                    authorGender = Gender.male;
                else
                    authorGender = Gender.female;
                DateTime authorBirthDay = (DateTime)reader["authorBirthDay"];
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
                DateTime d = (DateTime)reader["offTime"];
                long off = long.Parse(reader["off"].ToString());
                PDFBooks pdfBook = new PDFBooks(name, authorName, authorNationality, authorBirthDay, authorGender, authorBooks, summary, pdf_fileName, photoPath, vip, cost, point, publishYear, outcome, numberOfSoldBooks, monthlySubscriptionFee, off, d);
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
            int i = 1;
            foreach (PDFBooks pdfBook in pdfBookList)
            {
                command = "insert into [PDFBooksTable] values('" + i + "','" + pdfBook.Name.Trim() + "','" + pdfBook.AuthorName.Trim() + "','" + pdfBook.Cost + "','" + pdfBook.Summary.Trim()
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
                command += ",'" + pdfBook.AuthorBooks + "','" + pdfBook.AuthorNationality + "')";
                SqlCommand com = new SqlCommand(command, con);
                com.ExecuteNonQuery();
                i++;
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
            foreach (PDFBooks book in pdfBookList.Where(book => book.AuthorName.Contains(author)))
            {
                returnList.Add(book);
            }
            return returnList;
        }
        static public void SetVip(string bookName, long monthlySubscriptionFee)
        {
            PDFBooks pdfBook = pdfBookList.Where(book => book.Name == bookName) as PDFBooks;
            if (pdfBook != null)
                pdfBook.MonthlySubscriptionFee = monthlySubscriptionFee;
        }
        static public void SetOffDateAndOffCount(string bookName, long off, DateTime dateTime)
        {
            PDFBooks pdfBook = pdfBookList.Where(book => book.Name == bookName) as PDFBooks;
            if (pdfBook != null)
            {
                pdfBook.Off = off;
                pdfBook.OffDate = dateTime;
            }
        }
        static public string ViewOutCome(string bookName)
        {
            PDFBooks pdfBook = pdfBookList.Where(book => book.Name == bookName) as PDFBooks;
            if (pdfBook != null)
            {
                return "OutCome : " + pdfBook.Outcome.ToString() + "\nNumber Of Sold Books : " + pdfBook.NumberOfSoldBooks;
            }
            else
            {
                return "Entered Book Was Not Found!";
            }
        }
        static public int ViewPoint(string bookName)
        {
            PDFBooks pdfBook = pdfBookList.Where(book => book.Name == bookName) as PDFBooks;
            if (pdfBook != null)
                return pdfBook.Point;
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
                PDFBooks pdfBook = (PDFBooks)book;
                pdfBook.Off = 0;
            }
        }
        static public void ChangeBookName(string oldName, string newName)
        {
            PDFBooks pdfBook = pdfBookList.Where(book => book.Name == oldName) as PDFBooks;
            if (pdfBook != null)
                pdfBook.Name = newName;
        }
        static public void ChangeAuthorName(string bookName, string newAuthorName)
        {
            PDFBooks pdfBook = pdfBookList.Where(book => book.Name == bookName) as PDFBooks;
            if (pdfBook != null)
                pdfBook.AuthorName = newAuthorName;
        }
        static public void ChangeAuthorNationality(string bookName, string authorNewNationality)
        {
            PDFBooks pdfBook = pdfBookList.Where(book => book.Name == bookName) as PDFBooks;
            if (pdfBook != null)
                pdfBook.AuthorNationality = authorNewNationality;
        }
        static public void ChangeAuthorBirthDay(string bookName, DateTime newBirthDay)
        {
            PDFBooks pdfBook = pdfBookList.Where(book => book.Name == bookName) as PDFBooks;
            if (pdfBook != null)
                pdfBook.AuthorBirthDay = newBirthDay;
        }
        static public void ChangeAuthorGender(string bookName, Gender authorNewGender)
        {
            PDFBooks pdfBook = pdfBookList.Where(book => book.Name == bookName) as PDFBooks;
            if (pdfBook != null)
                pdfBook.AuthorGender = authorNewGender;
        }
        static public void ChangeAuthorBooks(string bookName, string authorNewBooks)
        {
            PDFBooks pdfBook = pdfBookList.Where(book => book.Name == bookName) as PDFBooks;
            if (pdfBook != null)
                pdfBook.AuthorBooks = authorNewBooks;
        }
        static public void ChangeSummary(string bookName, string newSummary)
        {
            PDFBooks pdfBook = pdfBookList.Where(book => book.Name == bookName) as PDFBooks;
            if (pdfBook != null)
                pdfBook.Summary = newSummary;
        }
        static public void ChangePdfFileName(string bookName, string newPdfFileName)
        {
            PDFBooks pdfBook = pdfBookList.Where(book => book.Name == bookName) as PDFBooks;
            if (pdfBook != null)
                pdfBook.PDF_FileName = newPdfFileName;
        }
        static public void ChangePhotoPath(string bookName, string newPhotoPath)
        {
            PDFBooks pdfBook = pdfBookList.Where(book => book.Name == bookName) as PDFBooks;
            if (pdfBook != null)
                pdfBook.PhotoPath = newPhotoPath;
        }
        static public void ChangeTypeToFree(string bookName)
        {
            PDFBooks pdfBook = pdfBookList.Where(book => book.Name == bookName) as PDFBooks;
            if (pdfBook != null)
            {
                pdfBook.bookType = Type.casual;
                pdfBook.MonthlySubscriptionFee = 0;
            }
        }
        static public void ChangeCost(string bookName, long newCost)
        {
            PDFBooks pdfBook = pdfBookList.Where(book => book.Name == bookName) as PDFBooks;
            if (pdfBook != null)
                pdfBook.Cost = newCost;
        }
        static public void ChangePoint(string bookName, int newPoint)
        {
            PDFBooks pdfBook = pdfBookList.Where(book => book.Name == bookName) as PDFBooks;
            if (pdfBook != null)
                pdfBook.Point = newPoint;
        }
        static public void ChangePublishYear(string bookName, int newPublishYear)
        {
            PDFBooks pdfBook = pdfBookList.Where(book => book.Name == bookName) as PDFBooks;
            if (pdfBook != null)
                pdfBook.PublishYear = newPublishYear;
        }
        static public void AddBookToGallery(PDFBooks newPDFBook)
        {
            PDFBooks.pdfBookList.Add(newPDFBook);
        }
        static public void OpenPDFBook(string bookName)
        {
            PDFBooks pdfBook = pdfBookList.Where(book => book.Name == bookName) as PDFBooks;
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
        public PDFBooks(
            string name,
            string authorName,
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
            this._ID = pdfBookList.Count + 1;
            this.Name = name;
            this.AuthorName = authorName;
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
