using System;

namespace Library.Core.Domain
{
    public class User
    {
        public Guid Id { get; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public Role Role { get; set; }

        public User(string email, string password, Role role) : this(Guid.NewGuid(), email, password, role)
        {
        }

        public User(Guid id, string email, string password, Role role)
        {
            Id = id;
            Email = email;
            Password = password;
        }
    }
}
