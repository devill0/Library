using Library.Core.Dto;
using System;

namespace Library.Web.Models
{
    public class BooksViewModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public decimal Price { get; set; }

        public BooksViewModel(BookDto bookDto)
        {
            Id = bookDto.Id;
            Title = bookDto.Title;
            Author = bookDto.Author;
            Price = bookDto.Price;
        }
    }
}
