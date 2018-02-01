using Library.Core.Domain;
using Library.Core.Repository;
using Library.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Library.Web.Controllers
{
    [Route("books")]
    public class BooksController : Controller
    {
        private readonly IBookRepository bookRepository;

        public BooksController(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;        
        }

        public IActionResult Index()
        {
            return View(bookRepository);
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

            bookRepository.Add(new Book(viewModel.Title, viewModel.Author, viewModel.Price));

            return View("Index");
        }
    }
}