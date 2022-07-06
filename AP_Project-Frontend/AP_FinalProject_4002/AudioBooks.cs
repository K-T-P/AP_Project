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
    class AudioBooks
    {
        static public ObservableCollection<AudioBooks> AudioBooksList = new ObservableCollection<AudioBooks>();

        private int _ID { get; set; }
        public string Name { get; private set; }
        public string AuthorName { get; private set; }
        public string AuthorNationality { get; private set; }
        public DateTime AuthorBirthDay { get; private set; }
        public Gender AuthorGender { get; private set; }
        public string AuthorBooks { get; private set; }
        public string Summary { get; private set; }
        public string MP3_FileName { get; private set; }
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
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + AppDomain.CurrentDomain.BaseDirectory + @"AudioBookServer\AudioBookServer.mdf;Integrated Security=True;Connect Timeout=30");
            string command = "select * from [AudioBookTable]";
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
                string pdf_fileName = reader["Audio_FileName"].ToString();
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
                AudioBooks audioBook = new AudioBooks(name, authorName, authorNationality, authorBirthDay, authorGender, authorBooks, summary, pdf_fileName, photoPath, vip, cost, point, publishYear, outcome, numberOfSoldBooks, monthlySubscriptionFee, off, d);
                AudioBooksList.Add(audioBook);
            }
            con.Close();
        }
        static public void AutoSave()
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + AppDomain.CurrentDomain.BaseDirectory + @"AudioBookServer\AudioBookServer.mdf;Integrated Security=True;Connect Timeout=30");
            string command;
            con.Open();
            command = "DELETE FROM [AudioBookTable]";
            SqlCommand cmd = new SqlCommand(command, con);
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            int i = 1;
            foreach (AudioBooks audioBook in AudioBooksList)
            {
                command = "insert into [AudioBookTable] values('" + i + "','" + audioBook.Name.Trim() + "','" + audioBook.AuthorName.Trim() + "','" + audioBook.Cost + "','" + audioBook.Summary.Trim()
                    + "','" + audioBook.Point + "'";
                if (audioBook.bookType == Type.vip)
                    command += ",'" + true + "'";
                else
                    command += ",'" + false + "'";
                command += ",'" + audioBook.Off + "','" + audioBook.OffDate + "','" + audioBook.PhotoPath.Trim() + "','" + audioBook.MP3_FileName.Trim() + "','" + audioBook.PublishYear + "'" +
                    ",'" + audioBook.Outcome + "','" + audioBook.NumberOfSoldBooks + "','" + audioBook.MonthlySubscriptionFee + "','" + audioBook.AuthorBirthDay + "'";
                if (audioBook.AuthorGender == Gender.male)
                    command += ",'" + true + "'";
                else
                    command += ",'" + false + "'";
                command += ",'" + audioBook.AuthorBooks + "','" + audioBook.AuthorNationality + "')";
                SqlCommand com = new SqlCommand(command, con);
                com.ExecuteNonQuery();
                i++;
            }
            con.Close();
        }
        static public ObservableCollection<AudioBooks> SearchByBookName(string bookName)
        {
            ObservableCollection<AudioBooks> returnList = new ObservableCollection<AudioBooks>();
            foreach (AudioBooks book in AudioBooksList.Where(book => book.Name.Contains(bookName)))
            {
                returnList.Add(book);
            }
            return returnList;
        }
        static public ObservableCollection<AudioBooks> SearchByAuthor(string author)
        {
            ObservableCollection<AudioBooks> returnList = new ObservableCollection<AudioBooks>();
            foreach (AudioBooks book in AudioBooksList.Where(book => book.AuthorName.Contains(author)))
            {
                returnList.Add(book);
            }
            return returnList;
        }
        static public void SetVip(string bookName, long monthlySubscriptionFee)
        {
            AudioBooks audioBook = AudioBooksList.Where(book => book.Name == bookName) as AudioBooks;
            if (audioBook != null)
                audioBook.MonthlySubscriptionFee = monthlySubscriptionFee;
        }
        static public void SetOffDateAndOffCount(string bookName, long off, DateTime dateTime)
        {
            AudioBooks audioBook = AudioBooksList.Where(book => book.Name == bookName) as AudioBooks;
            if (audioBook != null)
            {
                audioBook.Off = off;
                audioBook.OffDate = dateTime;
            }
        }
        static public string ViewOutCome(string bookName)
        {
            AudioBooks audioBook = AudioBooksList.Where(book => book.Name == bookName) as AudioBooks;
            if (audioBook != null)
            {
                return "OutCome : " + audioBook.Outcome.ToString() + "\nNumber Of Sold Books : " + audioBook.NumberOfSoldBooks;
            }
            else
            {
                return "Entered Book Was Not Found!";
            }
        }
        static public int ViewPoint(string bookName)
        {
            AudioBooks audioBook = AudioBooksList.Where(book => book.Name == bookName) as AudioBooks;
            if (audioBook != null)
                return audioBook.Point;
            else
                return -1;
        }
        static public void UpdateOffDates()
        {
            var resultList = AudioBooks.AudioBooksList
                  .Where(book => book.Off != 0)
                  .Where((AudioBooks book) => { int res = DateTime.Compare(DateTime.Now, book.OffDate); if (res >= 0) return true; else return false; });

            foreach (var book in resultList)
            {
                AudioBooks audioBook = (AudioBooks)book;
                audioBook.Off = 0;
            }
        }
        static public void ChangeBookName(string oldName, string newName)
        {
            AudioBooks audioBook = AudioBooksList.Where(book => book.Name == oldName) as AudioBooks;
            if (audioBook != null)
                audioBook.Name = newName;
        }
        static public void ChangeAuthorName(string bookName, string newAuthorName)
        {
            AudioBooks audioBook = AudioBooksList.Where(book => book.Name == bookName) as AudioBooks;
            if (audioBook != null)
                audioBook.AuthorName = newAuthorName;
        }
        static public void ChangeAuthorNationality(string bookName, string authorNewNationality)
        {
            AudioBooks audioBook = AudioBooksList.Where(book => book.Name == bookName) as AudioBooks;
            if (audioBook != null)
                audioBook.AuthorNationality = authorNewNationality;
        }
        static public void ChangeAuthorBirthDay(string bookName, DateTime newBirthDay)
        {
            AudioBooks audioBook = AudioBooksList.Where(book => book.Name == bookName) as AudioBooks;
            if (audioBook != null)
                audioBook.AuthorBirthDay = newBirthDay;
        }
        static public void ChangeAuthorGender(string bookName, Gender authorNewGender)
        {
            AudioBooks audioBook = AudioBooksList.Where(book => book.Name == bookName) as AudioBooks;
            if (audioBook != null)
                audioBook.AuthorGender = authorNewGender;
        }
        static public void ChangeAuthorBooks(string bookName, string authorNewBooks)
        {
            AudioBooks audioBook = AudioBooksList.Where(book => book.Name == bookName) as AudioBooks;
            if (audioBook != null)
                audioBook.AuthorBooks = authorNewBooks;
        }
        static public void ChangeSummary(string bookName, string newSummary)
        {
            AudioBooks audioBook = AudioBooksList.Where(book => book.Name == bookName) as AudioBooks;
            if (audioBook != null)
                audioBook.Summary = newSummary;
        }
        static public void ChangePdfFileName(string bookName, string newPdfFileName)
        {
            AudioBooks audioBook = AudioBooksList.Where(book => book.Name == bookName) as AudioBooks;
            if (audioBook != null)
                audioBook.MP3_FileName = newPdfFileName;
        }
        static public void ChangePhotoPath(string bookName, string newPhotoPath)
        {
            AudioBooks audioBook = AudioBooksList.Where(book => book.Name == bookName) as AudioBooks;
            if (audioBook != null)
                audioBook.PhotoPath = newPhotoPath;
        }
        static public void ChangeTypeToFree(string bookName)
        {
            AudioBooks audioBook = AudioBooksList.Where(book => book.Name == bookName) as AudioBooks;
            if (audioBook != null)
            {
                audioBook.bookType = Type.casual;
                audioBook.MonthlySubscriptionFee = 0;
            }
        }
        static public void ChangeCost(string bookName, long newCost)
        {
            AudioBooks audioBook = AudioBooksList.Where(book => book.Name == bookName) as AudioBooks;
            if (audioBook != null)
                audioBook.Cost = newCost;
        }
        static public void ChangePoint(string bookName, int newPoint)
        {
            AudioBooks audioBook = AudioBooksList.Where(book => book.Name == bookName) as AudioBooks;
            if (audioBook != null)
                audioBook.Point = newPoint;
        }
        static public void ChangePublishYear(string bookName, int newPublishYear)
        {
            AudioBooks audioBook = AudioBooksList.Where(book => book.Name == bookName) as AudioBooks;
            if (audioBook != null)
                audioBook.PublishYear = newPublishYear;
        }
        static public void AddBookToGallery(AudioBooks newAudioBook)
        {
            AudioBooks.AudioBooksList.Add(newAudioBook);
        }
        static public void PlayBook(string audioBookName)
        {
            AudioBooks audioBook = AudioBooksList.Where(aBook => aBook.Name == audioBookName) as AudioBooks;
            if (audioBook != null)
            {
                AudioBookPlayer mp3Player = new AudioBookPlayer(audioBook.MP3_FileName);
                mp3Player.Show();
            }
        }
        public AudioBooks(
            string name,
            string authorName,
            string authorNationality,
            DateTime authorBirthDay,
            Gender authorGender,
            string authorBooks,
            string summary,
            string audioFileName,
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
            this._ID = AudioBooksList.Count + 1;
            this.Name = name;
            this.AuthorName = authorName;
            this.AuthorNationality = authorNationality;
            this.AuthorGender = authorGender;
            this.AuthorBirthDay = authorBirthDay;
            this.AuthorBooks = authorBooks;
            this.Summary = summary;
            this.MP3_FileName = audioFileName;
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
