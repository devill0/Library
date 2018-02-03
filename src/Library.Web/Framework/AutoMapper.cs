using AutoMapper;
using Library.Core.Domain;
using Library.Core.Dto;

namespace Library.Web.Framework
{
    public static class AutoMapper
    {
        public static IMapper GetMapper()
            => new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Book, BookDto>();

            }).CreateMapper();
    }   
}
