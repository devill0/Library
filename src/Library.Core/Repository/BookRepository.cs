using System;
using System.Collections.Generic;
using System.Linq;
using Library.Core.Domain;

namespace Library.Core.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly static ISet<Book> books = new HashSet<Book>()
        {
            new Book("Harry Potter and the Philosopher's Stone", "J. K. Rowlling", 5.0M),
            new Book("Harry Potter and the Chamber of Secrets", "J. K. Rowlling", 6.0M),
        };

        public void Add(Book book)
            => books.Add(book);

        public void Delete(Guid id)
            => books.Remove(Get(id));

        public Book Get(Guid id)
            => books.SingleOrDefault(b => b.Id == id);

        public IEnumerable<Book> GetAll()
            => books;

        public void Update(Book book)
        {            
        }
    }
}
