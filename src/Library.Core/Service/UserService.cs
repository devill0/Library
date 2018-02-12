using System;
using System.Collections.Generic;
using AutoMapper;
using Library.Core.Domain;
using Library.Core.Dto;
using Library.Core.Repository;

namespace Library.Core.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
        }        

        public UserDto Get(Guid id)
        {
            var user = userRepository.Get(id);

            return user == null ? null : mapper.Map<UserDto>(user);
        }

        public UserDto Get(string email)
        {
            var user = userRepository.Get(email);           

            return user == null ? null : mapper.Map<UserDto>(user);
        }

        public void Login(string email, string password)
        {
            var user = userRepository.Get(email);
            if (user == null)
            {
                throw new KeyNotFoundException($"There is no user match to '{email}' email adress.");
            }
            if (user.Password != password)
            {
                throw new KeyNotFoundException("Invalid password");
            }
        }

        public void Register(string email, string password, RoleDto role)
        {
            var user = userRepository.Get(email);
            if (user != null)
            {
                throw new Exception($"Email adress '{email}' already exists. Please choose another one to register.");
            }
            var userRole = (Role)Enum.Parse(typeof(Role), role.ToString(), true);
            user = new User(email, password, userRole);
            userRepository.Add(user);
        }
    }
}
