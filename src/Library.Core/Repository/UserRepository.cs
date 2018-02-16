using System;
using System.Collections.Generic;
using System.Linq;
using Library.Core.Domain;

namespace Library.Core.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly static ISet<User> users = new HashSet<User>
        {
            new User("admin@library.com", "secret", Role.Admin),
            new User("user@library.com", "secret", Role.User),
        };

        public void Add(User user)
            => users.Add(user);

        public void Delete(User user)
            => users.Remove(user);

        public User Get(Guid id)        
            => users.SingleOrDefault(u => u.Id == id);

        public User Get(string email)
            => users.SingleOrDefault(u => string.Equals(u.Email, email, StringComparison.InvariantCultureIgnoreCase));

        public IEnumerable<User> GetAll()
            => users;
    }
}
