using Library.Core.Domain;
using Library.Core.Dto;
using System;
using System.Collections.Generic;

namespace Library.Core.Service
{
    public interface IUserService
    {
        UserDto Get(Guid id);
        UserDto Get(string email);
        void Login(string email, string password);
        void Register(string email, string password, RoleDto role);
    }
}
