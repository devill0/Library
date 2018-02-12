using AutoMapper;
using Library.Core.Domain;
using Library.Core.Dto;

namespace Library.Web.Framework
{
    public static class AutoMapperConfig
    {
        public static IMapper GetMapper()
            => new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Book, BookDto>();
                cfg.CreateMap<User, UserDto>();

            }).CreateMapper();
    }   
}
