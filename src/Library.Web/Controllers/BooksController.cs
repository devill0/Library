using Library.Core.Service;
using Library.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Library.Web.Controllers
{
    [Route("books")]
    public class BooksController : Controller
    {
        private readonly IBookService bookService;

        public BooksController(IBookService bookService)
        {
            this.bookService = bookService;        
        }

        public IActionResult Index()
        {
            var books = bookService.GetAll()
                                   .Select(b => new BooksViewModel(b));

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

            bookService.Add(viewModel.Id, viewModel.Title, viewModel.Author, viewModel.Price);

            return View("Index");
        }
    }
}