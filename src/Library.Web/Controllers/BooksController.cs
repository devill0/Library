using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Library.Web.Controllers
{
    [Route("books")]
    public class BooksController : Controller
    {
        private static List<BooksViewModel> books;

        public BooksController()
        {
            if (books == null)
            {
                books = new List<BooksViewModel>();
                books.Add(new BooksViewModel { Id = Guid.NewGuid(), Title = "Harry Potter and the Philosopher's Stone", Author = "J. K. Rowlling", Price = 5.0M });
                books.Add(new BooksViewModel { Id = Guid.NewGuid(), Title = "Harry Potter and the Chamber of Secrets", Author = "J. K. Rowlling", Price = 3.9M });
                books.Add(new BooksViewModel { Id = Guid.NewGuid(), Title = "C# Head first!", Author = "Jennifer Greene, Andrew Stellman", Price = 10.0M });
            }                                    
        }

        public IActionResult Index()
        {
            return View(books);
        }

        [HttpGet("add")]
        public IActionResult AddBook()
        {           
            return View();
        }

        [HttpPost("add")]
        public IActionResult AddBook(BooksViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            books.Add(new BooksViewModel());

            return View("Index");
        }
    }
}