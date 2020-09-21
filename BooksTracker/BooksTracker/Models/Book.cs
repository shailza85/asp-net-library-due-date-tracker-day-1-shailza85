using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksTracker.Models
{
    public class Book
    {
        public string Title { get;}

        public DateTime PublicationDate { get; }

        public DateTime CheckedOutDate { get; set; }
    }
}
