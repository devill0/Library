using System;
using Library.Core.Domain;
using Library.Core.Dto;
using Library.Core.Repository;

namespace Library.Core.Service
{
    public class BookService : IBookService
    {
        private readonly IBookRepository bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }

        public void Add(Guid id, string title, string author, decimal price)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid id)
            => bookRepository.Delete(id);

        public Book Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public BookDto GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(BookDto bookDto)
        {
            var existingBook = bookRepository.Get(bookDto.Id);
            if (existingBook == null)
            {
                throw new Exception($"Book with id:{bookDto.Id} was not found.");
            }
            //Need to add code witch update the existingBook in Domain file
            bookRepository.Update(existingBook);
        }
    }
}
