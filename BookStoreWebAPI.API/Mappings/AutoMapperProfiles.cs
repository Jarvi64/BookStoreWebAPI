using AutoMapper;
using BookStoreWebAPI.API.Models.Domain;
using BookStoreWebAPI.API.Models.DTO;namespace BookStoreWebAPI.API.Mappings
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles() 
        {
            CreateMap<Author,AuthorDto>().ReverseMap();
            CreateMap<AddAuthorDto,Author>().ReverseMap();
            CreateMap<UpdateAuthorDto,Author>().ReverseMap();            CreateMap<Book, BookDto>().ReverseMap();
            CreateMap<AddBookDto, Book>().ReverseMap();
            CreateMap<UpdateBookDto, Book>().ReverseMap();            CreateMap<Genre,GenreDto>().ReverseMap();
        }
    }
}
