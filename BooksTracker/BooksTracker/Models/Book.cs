using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksTracker.Models
{
    public class Book
    {
        /*
         * Book class (Model):
            string “Title”
            This property should be readOnly (getter only, backing variable initialized via constructor)

            DateTime “PublicationDate”
            This property should be readOnly (getter only, backing variable initialized via constructor)

            DateTime “CheckedOutDate”

            DateTime “DueDate”
            This will equal “CheckedOutDate” + 14 days (set in constructor)
            This will update with each extension (via the ExtendDueDateForBookByID() method)

            DateTime “ReturnedDate”
            Default value should be null (set in constructor)

            string “Author”
            This property should be readOnly (getter only, backing variable initialized via constructor)

            int “ID”
            This property should be readOnly (getter only, backing variable initialized via constructor)
            This property will be auto-incremented by the database in tomorrow’s practice
            User will have to add “ID” on Day 1 and the code will have to validate that the “ID” is unique (in the CreateBook() method)

            Constructor accepting the ID, Title, Author, PublicationDate and CheckedOutDate as parameters

            “DueDate” will be set to 14 days after “CheckedOutDate”

            “ReturnedDate” will be set to null

         */

        private string _title;
        public string Title
        {
            get
            {
                return _title;
            }
        }

        private DateTime _publicationdate;
        public DateTime PublicationDate
        {
            get
            {
                return _publicationdate;
            }
        }

        public DateTime CheckedOutDate { get; set; }
        public DateTime DueDate { get; set; }

        public DateTime? ReturnedDate { get; set; }

        private string _author;
        public string Author
        {
            get
            {
                return _author;
            }
        }

        private int _id;
        public int ID
        {
            get
            {
                return _id;
            }
        }


        public Book()
        {
            this._id = 1;
            this._title = "Nineteen Eighty-Four";
            this._author = "George Orwell";
            this._publicationdate = new DateTime(1949/06/08);
            CheckedOutDate = new DateTime(2020/09/20);
            DueDate = CheckedOutDate.AddDays(14);
            ReturnedDate = null;

        }

        public Book(int id, string title, string author, DateTime publicationDate, DateTime checkoutdate)
        {
            this._id = id;
            this._title = title;
            this._author = author;
            this._publicationdate = publicationDate;
            DueDate = checkoutdate.AddDays(14);
            ReturnedDate = null;

        }

    }
}


// Code borowed: @ link https://github.com/TECHCareers-by-Manpower/4.1-MVC/tree/master/MVC_4Point1
