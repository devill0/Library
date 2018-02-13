using AutoMapper;
using Library.Core.Domain;
using Library.Core.Dto;
using System;

namespace Library.Web.Framework
{
    public static class AutoMapperConfig
    {
        public static IMapper GetMapper()
            => new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Book, BookDto>();

                cfg.CreateMap<User, UserDto>().ForMember(m => m.Role,
                    o => o.MapFrom(p => (RoleDto)Enum.Parse(typeof(RoleDto), p.Role.ToString(), true)));  
            }).CreateMapper();
    }   
}
