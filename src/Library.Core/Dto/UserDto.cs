using System;

namespace Library.Core.Dto
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public RoleDto Role { get; set; }
    }
}
