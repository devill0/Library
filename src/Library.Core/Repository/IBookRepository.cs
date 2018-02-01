using Library.Core.Domain;
using System;
using System.Collections.Generic;

namespace Library.Core.Repository
{
    public interface IBookRepository
    {
        Book Get(Guid id);
        IEnumerable<Book> GetAll();
        void Add(Book book);
        void Delete(Guid id);        
        void Update(Book book);
    }
}
