using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BooksTracker.Controllers;
using BooksTracker.Models;
using Microsoft.VisualBasic;

namespace BooksTracker.Controllers
{
    public class BookController : Controller
    {
        //A public static "Books" property which is a list of "Book" objects.
        //This will be replaced by a proper database on {Day 2 assignment title}.
        static public List<Book> Books { get; set; } = new List<Book>();
        public IActionResult Create()
        {
            return View();
        }
        /**
         * Method "CreateBook()".
            Accepts the same parameters as the "Book" constructor.
            Creates and adds a "Book" to the "Books" list.
            Ensures the provided ID is unique in the list.
            Throw an exception if the ID already exists.
         */
        public IActionResult CreateBook(string id, string title, string author, DateTime publicationDate, DateTime checkOutDate, DateTime dueDate)
        {
            // A request has come in that has some data stored in the query (GET or POST).
            if (Request.Query.Count > 0)
            {
                if (id != null && title != null && author != null && publicationDate != null && checkOutDate != null && dueDate != null)
                {
                    // All expected data provided, so this will be our submit state.
                    Books.Add(new Book()
                    {
                      //ID = int.Parse(id),
                       // Title = title,
                       // Author = author,
                      //  PublicationDate = publicationDate,
                        CheckedOutDate = checkOutDate,
                        DueDate = dueDate,
                        ReturnedDate = null,
                    });

                    ViewBag.Success = $"You have successfully checked out {title} until {dueDate} ";
                }
                else
                {
                    // All expected data not provided, so this will be our error state.
                    ViewBag.Error = "Unable to check out book";
                    // Store our data to re-add to the form.
                    ViewBag.ID = id;
                    ViewBag.Title = title;
                    ViewBag.Author = author;
                    ViewBag.PublicationDate = publicationDate;
                    ViewBag.CheckOutDate = checkOutDate;
                    ViewBag.DueDate = checkOutDate.AddDays(14);
                    ViewBag.ReturnedDate = null;
                }
            }
            // else
            // No request, so this will be our inital state.
            return View();
        }
        public IActionResult List()
        {
            ViewBag.Book = Books;
            return View();
        }
        public IActionResult Details(string id, string delete)
        {
            IActionResult result;
            if (delete != null)
            {
                DeleteBookByID(int.Parse(id));
                result = RedirectToAction("List");
            }
            else
            {
                ViewBag.Book = GetBookByID(int.Parse(id));
                result = View();
            }
            return result;
        }
        // Method "ExtendDueDateForBookByID()".

        // Extensions are 7 days from the current date(7 days from when the user requests the extension, not 7 days past the "DueDate").
        public DateTime ExtendDueDateForBookById(int id)
        {
             DateTime DueDate = DateTime.Now.AddDays(7);
            return DueDate;
        }

        //Method "GetBookByID()".
        // Returns the book with the given ID from the "Books" list.
        public Book GetBookByID(int id)
        {
            return Books.Where(x => x.ID == id).Single();
        }

        //Method "DeleteBookByID()".
        //Removes the book with the given ID from the "Books" list.

        public void DeleteBookByID(int id)
        {
            Books.Remove(Books.Where(x => x.ID == id).Single());
        }

        /*
         * ActionResult “ViewBooks”
        Display: "You checked out {title} on {CheckedOutDate}, and it {is/was} due on {DueDate}."
        Use conditional rendering to make a choice about using ‘is’ or ‘was’ based on today’s date.

         */

       public IActionResult ViewBookByID(string id, string title, DateTime checkOutDate)
        {
           
            ViewBag.ID = id;
            ViewBag.Title = title;           
            ViewBag.CheckOutDate = checkOutDate;
            ViewBag.DueDate = checkOutDate.AddDays(14);


            if (ViewBag.CheckOutDate == DateTime.Now)
            { 
           

                ViewBag.Book = GetBookByID(int.Parse(id));
                ViewBag.Success = $"You checked out {title} on {ViewBag.CheckOutDate}, and it is due on {ViewBag.DueDate} ";
            }

            else
            {
                ViewBag.Success = $"You checked out {title} on {ViewBag.CheckOutDate}, and it was due on {ViewBag.DueDate.Subtract(DateTime.Now)} ";
            }

            return View();
        }
    }

    // Code borowed: @ link https://github.com/TECHCareers-by-Manpower/4.1-MVC/tree/master/MVC_4Point1
}
