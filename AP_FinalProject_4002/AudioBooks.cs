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
    public class AudioBooks
    {
        static public ObservableCollection<AudioBooks> AudioBooksList = new ObservableCollection<AudioBooks>();
        static private int ID_Generator = 0;

        public int _ID { get; set; }
        public string Name { get; private set; }
        public string AuthorFirstName { get; private set; }
        public string AuthorLastName { get; private set; }
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
                int ID = int.Parse(reader["Id"].ToString());
                AudioBooks.ID_Generator = int.Parse(reader["ID_Generator"].ToString());
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
                string audio_fileName = reader["Audio_FileName"].ToString();
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
                AudioBooks audioBook = new AudioBooks(ID, name, authorFirstName, authorLastName, authorNationality, authorBirthDay, authorGender, authorBooks, summary, audio_fileName, photoPath, vip, cost, point, publishYear, outcome, numberOfSoldBooks, monthlySubscriptionFee, off, d);
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
            foreach (AudioBooks audioBook in AudioBooksList)
            {
                command = "insert into [AudioBookTable] values('" + audioBook._ID + "','" + audioBook.Name.Trim() + "','" + audioBook.AuthorFirstName.Trim() + "','" + audioBook.Cost + "','" + audioBook.Summary.Trim()
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
                command += ",'" + audioBook.AuthorBooks + "','" + audioBook.AuthorNationality + "','" + audioBook.AuthorLastName.Trim() + "','" + AudioBooks.ID_Generator + "')";
                SqlCommand com = new SqlCommand(command, con);
                com.ExecuteNonQuery();
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
            foreach (AudioBooks book in AudioBooksList.Where(book => book.AuthorLastName.Contains(author)))
            {
                returnList.Add(book);
            }
            return returnList;
        }
        static public void SetVip(int bookID, long monthlySubscriptionFee)
        {
            var searchResult = AudioBooksList.Where(book => book._ID == bookID);
            AudioBooks audioBook = null;
            foreach (var i in searchResult)
            {
                audioBook = (AudioBooks)i;
            }
            if (audioBook != null)
                audioBook.MonthlySubscriptionFee = monthlySubscriptionFee;
        }
        static public void SetOffDateAndOffCount(int bookID, long off, DateTime dateTime)
        {
            var searchResult = AudioBooksList.Where(book => book._ID == bookID);
            AudioBooks audioBook = null;
            foreach (var i in searchResult)
            {
                audioBook = (AudioBooks)i;
            }
            if (audioBook != null)
            {
                audioBook.Off = off;
                audioBook.OffDate = dateTime;
            }
        }
        static public string ViewOutCome(int bookID)
        {
            var searchResult = AudioBooksList.Where(book => book._ID == bookID);
            AudioBooks audioBook = null;
            foreach (var i in searchResult)
            {
                audioBook = (AudioBooks)i;
            }
            if (audioBook != null)
                return "OutCome : " + audioBook.Outcome.ToString() + "\nNumber Of Sold Books : " + audioBook.NumberOfSoldBooks;
            else
                return "Entered Book Was Not Found!";

        }
        static public int ViewPoint(int bookID)
        {
            var searchResult = AudioBooksList.Where(book => book._ID == bookID);
            AudioBooks audioBook = null;
            foreach (var i in searchResult)
            {
                audioBook = (AudioBooks)i;
            }
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
                AudioBooks audioBook = book as AudioBooks;
                if (audioBook != null)
                    audioBook.Off = 0;
            }
        }
        static public void ChangeBookName(int bookID, string newName)
        {
            var searchResult = AudioBooksList.Where(book => book._ID == bookID);
            AudioBooks audioBook = null;
            foreach (var i in searchResult)
            {
                audioBook = (AudioBooks)i;
            }
            if (audioBook != null)
                audioBook.Name = newName;
        }
        static public void ChangeAuthorFirstName(int bookID, string newAuthorFirstName)
        {
            var searchResult = AudioBooksList.Where(book => book._ID == bookID);
            AudioBooks audioBook = null;
            foreach (var i in searchResult)
            {
                audioBook = (AudioBooks)i;
            }
            if (audioBook != null)
                    audioBook.AuthorFirstName = newAuthorFirstName;
            }
        static public void ChangeAuthorLastName(int bookID, string newAuthorLastName)
        {
            var searchResult = AudioBooksList.Where(book => book._ID == bookID);
            AudioBooks audioBook = null;
            foreach (var i in searchResult)
            {
                audioBook = (AudioBooks)i;
            }
            if (audioBook != null)
                    audioBook.AuthorLastName = newAuthorLastName;
            }
        static public void ChangeAuthorNationality(int bookID, string authorNewNationality)
        {
            var searchResult = AudioBooksList.Where(book => book._ID == bookID);
            AudioBooks audioBook = null;
            foreach (var i in searchResult)
            {
                audioBook = (AudioBooks)i;
            }
            if (audioBook != null)
                    audioBook.AuthorNationality = authorNewNationality;
            }
        static public void ChangeAuthorBirthDay(int bookID, DateTime newBirthDay)
        {
            var searchResult = AudioBooksList.Where(book => book._ID == bookID);
            AudioBooks audioBook = null;
            foreach (var i in searchResult)
            {
                audioBook = (AudioBooks)i;
            }
            if (audioBook != null)
                    audioBook.AuthorBirthDay = newBirthDay;
            }
        static public void ChangeAuthorGender(int bookID, Gender authorNewGender)
        {
            var searchResult = AudioBooksList.Where(book => book._ID == bookID);
            AudioBooks audioBook = null;
            foreach (var i in searchResult)
            {
                audioBook = (AudioBooks)i;
            }
            if (audioBook != null)
                    audioBook.AuthorGender = authorNewGender;
            }
        static public void ChangeAuthorBooks(int bookID, string authorNewBooks)
        {
            var searchResult = AudioBooksList.Where(book => book._ID == bookID);
            AudioBooks audioBook = null;
            foreach (var i in searchResult)
            {
                audioBook = (AudioBooks)i;
            }
            if (audioBook != null)
                    audioBook.AuthorBooks = authorNewBooks;
            }
        static public void ChangeSummary(int bookID, string newSummary)
        {
            var searchResult = AudioBooksList.Where(book => book._ID == bookID);
            AudioBooks audioBook = null;
            foreach (var i in searchResult)
            {
                audioBook = (AudioBooks)i;
            }
            if (audioBook != null)
                    audioBook.Summary = newSummary;
            }
        static public void ChangeAudioFileName(int bookID, string newAudioFileName)
        {
            var searchResult = AudioBooksList.Where(book => book._ID == bookID);
            AudioBooks audioBook = null;
            foreach (var i in searchResult)
            {
                audioBook = (AudioBooks)i;
            }
            if (audioBook != null)
                {
                    string fileExistencePath = AppDomain.CurrentDomain.BaseDirectory + @"AudioBookMP3Files\" + newAudioFileName;
                    if (File.Exists(fileExistencePath))
                        audioBook.MP3_FileName = newAudioFileName;
                }
            }
        static public void ChangePhotoPath(int bookID, string newPhotoPath)
        {
            var searchResult = AudioBooksList.Where(book => book._ID == bookID);
            AudioBooks audioBook = null;
            foreach (var i in searchResult)
            {
                audioBook = (AudioBooks)i;
            }
            if (audioBook != null)
                {
                    string fileExistencePath = AppDomain.CurrentDomain.BaseDirectory + @"Pictures\" + newPhotoPath;
                    if (File.Exists(fileExistencePath))
                        audioBook.PhotoPath = newPhotoPath;
                }
            }
        static public void ChangeTypeToFree(int bookID)
        {
            var searchResult = AudioBooksList.Where(book => book._ID == bookID);
            AudioBooks audioBook = null;
            foreach (var i in searchResult)
            {
                audioBook = (AudioBooks)i;
            }
            if (audioBook != null)
                {
                    audioBook.bookType = Type.casual;
                    audioBook.MonthlySubscriptionFee = 0;
                }
            }
        static public void ChangeCost(int bookID, long newCost)
        {
            var searchResult = AudioBooksList.Where(book => book._ID == bookID);
            AudioBooks audioBook = null;
            foreach (var i in searchResult)
            {
                audioBook = (AudioBooks)i;
            }
            if (audioBook != null)
                    audioBook.Cost = newCost;
            }
        static public void ChangePoint(int bookID, int newPoint)
        {
            var searchResult = AudioBooksList.Where(book => book._ID == bookID);
            AudioBooks audioBook = null;
            foreach (var i in searchResult)
            {
                audioBook = (AudioBooks)i;
            }
            if (audioBook != null)
                    audioBook.Point = newPoint;
            }
        static public void ChangePublishYear(int bookID, int newPublishYear)
        {
            var searchResult = AudioBooksList.Where(book => book._ID == bookID);
            AudioBooks audioBook = null;
            foreach (var i in searchResult)
            {
                audioBook = (AudioBooks)i;
            }
            if (audioBook != null)
                    audioBook.PublishYear = newPublishYear;
            }
        static public void AddBookToGallery(AudioBooks newAudioBook)
        {
            AudioBooks.AudioBooksList.Add(newAudioBook);
        }
        static public void PlayBook(int bookID)
        {
            var searchResult = AudioBooksList.Where(aBook => aBook._ID == bookID);
            AudioBooks audioBook = null;
            foreach (var i in searchResult)
            {
                audioBook = (AudioBooks)i;
            }
            if (audioBook != null)
                {
                    AudioBookPlayer mp3Player = new AudioBookPlayer(audioBook.MP3_FileName);
                    mp3Player.Show();
                }
            }
        public AudioBooks(
            string name,
            string authorFirstName,
            string authorLastName,
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
            ID_Generator++;
            this._ID = ID_Generator;
            this.Name = name;
            this.AuthorFirstName = authorFirstName;
            this.AuthorLastName = authorLastName;
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
        public AudioBooks(
            int ID,
            string name,
            string authorFirstName,
            string authorLastName,
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
            this._ID = ID;
            this.Name = name;
            this.AuthorFirstName = authorFirstName;
            this.AuthorLastName = authorLastName;
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
