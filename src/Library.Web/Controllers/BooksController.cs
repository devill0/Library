using Library.Core.Service;
using Library.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

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

        [HttpGet]
        public IActionResult Index()
        {
            var books = bookService.GetAll()
                                   .Select(b => new BooksViewModel(b));

            return View(books);
        }

        [HttpGet("add")]
        public IActionResult AddBook()
        {
            var viewModel = new AddBookViewModel();

            return View(viewModel);
        }

        [HttpPost("add")]
        public IActionResult AddBook(AddBookViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }
            bookService.Add(viewModel.Id, viewModel.Title, viewModel.Author, viewModel.Price);
           
            return RedirectToAction(nameof(Index));
        }
    }
}