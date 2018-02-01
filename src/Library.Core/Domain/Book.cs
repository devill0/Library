using System;

namespace Library.Core.Domain
{
    public class Book
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public decimal Price { get; set; }

        public Book(string title, string author, decimal price)
        {
            Id = Guid.NewGuid();
            Title = title;
            Author = author;
            Price = price;
        }
    }
}
