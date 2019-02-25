using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IndyBooks.Models;
using Microsoft.AspNetCore.Mvc;

namespace IndyBooks.Controllers
{
    public class AdminController : Controller
    {
        private IndyBooksDataContext _db;
        public AdminController(IndyBooksDataContext db) { _db = db; }

        public IActionResult Search()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Search(Book searchBook)
        {
            IEnumerable<Book> foundBooks = _db.Books; // start with entire collection

            //Return all books, if the search is empty
            if (searchBook == null)
            {
                return View("SearchResults", foundBooks);
            }

            //Otherwise, check each field and modify the collection accordingly
            if (searchBook.Title != null)
            {
                //Filter the collection by Title which "contains" string 
                //(Note: searchBook is the info from the form)
                // TODO: order the results by Title
                foundBooks = foundBooks
                             .Where(b => b.Title.Contains(searchBook.Title));
            }

            //TODO: add logic to filter the collection by Author info, if given 
            // (Note: you will need to adjust the View to add a search field)

            //TODO: add logic to filter the collection by the Edition number, if given
            // (Note: you will need to adjust the View to add a search field)

            //TODO: add logic to filter the collection by price below the price info, if given
            //       order results by descending price 
            // (Note: you will need to adjust the View to add a search field)

            return View("SearchResults", foundBooks);
        }
    }
}
