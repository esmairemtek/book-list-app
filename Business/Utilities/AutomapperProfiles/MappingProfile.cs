using AutoMapper;
using Entity.Concrete;
using Entity.DTOs.Details;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Utilities.AutomapperProfiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // author to authordetaildto
            CreateMap<Author, AuthorDetailDto>();

            // genre to genredetaildto
            CreateMap<Genre, GenreDetailDto>();

            // book to bookdetaildto
            CreateMap<Book, BookDetailDto>()
                .ForMember(dest => dest.Authors, opt => opt.MapFrom(src => src.Authors))
                .ForMember(dest => dest.Genres, opt => opt.MapFrom(src => src.Genres));


            // booklist to booklistdetaildto
            CreateMap<BookList, BookListDetailDto>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => $"{src.User.FirstName} {src.User.LastName}"))
                .ForMember(dest => dest.Books, opt => opt.MapFrom(src => src.Books));

            //CreateMap<User, UserDetailDto>();
        }
    }
}
