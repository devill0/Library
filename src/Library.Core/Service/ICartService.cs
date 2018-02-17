using Library.Core.Dto;
using System;

namespace Library.Core.Service
{
    public interface ICartService
    {
        CartDto Get(Guid userId);
        void AddBook(Guid userId, Guid bookId);
        void DeleteBook(Guid userId, Guid bookId);
        void Clear(Guid userId);
        void Create(Guid userId);
        void Delete(Guid userId);
    }
}
