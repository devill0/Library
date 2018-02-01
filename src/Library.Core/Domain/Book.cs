using System;

namespace Library.Core.Domain
{
    public class Book
    {
        public Guid Id { get; }
        public string Title { get; private set; }
        public string Author { get; private set; }
        public decimal Price { get; private set; }

        public Book(string title, string author, decimal price)
        {
            Id = Guid.NewGuid();
            Title = title;
            Author = author;
            Price = price;
        }
    }
}
