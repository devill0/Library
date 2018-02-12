using Library.Core.Dto;
using System;
using System.ComponentModel.DataAnnotations;

namespace Library.Web.Models
{
    public class BooksViewModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage ="Title is required.")]
        public string Title { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Author is required.")]
        public string Author { get; set; }
        public decimal Price { get; set; }

        public BooksViewModel()
        {
        }

        public BooksViewModel(BookDto bookDto)
        {
            Id = bookDto.Id;
            Title = bookDto.Title;
            Author = bookDto.Author;
            Price = bookDto.Price;
        }
    }
}
