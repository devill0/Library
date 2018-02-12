using Library.Core.Domain;
using System;
using System.Collections.Generic;

namespace Library.Core.Repository
{
    public interface IUserRepository
    {
        void Add(User user);
        void Delete(User user);
        User Get(Guid id);
        User Get(string email);
        IEnumerable<User> GetAll();
    }
}
