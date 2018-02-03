using Library.Core.Domain;
using Library.Core.Dto;
using System;
using System.Collections.Generic;

namespace Library.Core.Service
{
    public interface IBookService
    {
        BookDto Get(Guid id);
        IEnumerable<BookDto> GetAll();
        void Add(Guid id, string title, string author, decimal price);
        void Delete(Guid id);
        void Update(BookDto bookDto);
    }
}
