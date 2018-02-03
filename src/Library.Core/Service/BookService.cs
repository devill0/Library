using System;
using System.Collections.Generic;
using AutoMapper;
using Library.Core.Domain;
using Library.Core.Dto;
using Library.Core.Repository;

namespace Library.Core.Service
{
    public class BookService : IBookService
    {
        private readonly IBookRepository bookRepository;
        private readonly IMapper mapper;

        public BookService(IBookRepository bookRepository, IMapper mapper)
        {
            this.bookRepository = bookRepository;
            this.mapper = mapper;
        }

        public void Add(Guid id, string title, string author, decimal price)
        {
            var book = new Book(id, title, author, price);
            bookRepository.Add(book);
        }

        public void Delete(Guid id)
            => bookRepository.Delete(id);

        public BookDto Get(Guid id)
        {
            var book = bookRepository.Get(id);

            return book == null ? null : mapper.Map<BookDto>(book);
        } 
        
        public IEnumerable<BookDto> GetAll()
        {
            var books = bookRepository.GetAll();

            return mapper.Map<IEnumerable<BookDto>>(books);
        }

        public void Update(BookDto bookDto)
        {
            var existingBook = bookRepository.Get(bookDto.Id);
            if (existingBook == null)
            {
                throw new Exception($"Book with id:{bookDto.Id} was not found.");
            }
            //Need to add code which update the existingBook in Domain file
            bookRepository.Update(existingBook);
        }
    }
}
