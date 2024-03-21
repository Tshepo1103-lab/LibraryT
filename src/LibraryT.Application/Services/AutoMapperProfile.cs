using AutoMapper;
using LibraryT.Authorization.Users;
using LibraryT.Domain;
using LibraryT.Services.BookService.Dto;
using LibraryT.Services.CategoryService.Dto;
using LibraryT.Services.PersonService.Dto;
using LibraryT.Services.ShelfService.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryT.Services
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Shelf, ShelfDto>().ReverseMap();

            CreateMap<Category, CategoryDto>()
            .ForMember(x => x.ShelfId, e => e.MapFrom(x => x.Shelf.Id))
            .ReverseMap();

            CreateMap<Book, BookDto>()
            .ForMember(x => x.CategoryId, e => e.MapFrom(x => x.Category.Id))
            .ReverseMap();

            CreateMap<PersonDto, Person>()
            .ForMember(e => e.Id, d => d.Ignore());

            CreateMap<PersonDto, User>()
                .ForMember(x => x.Name, m => m.MapFrom(x => x.Name))
                .ForMember(x => x.PhoneNumber, m => m.MapFrom(x => x.PhoneNumber))
                .ForMember(x => x.EmailAddress, m => m.MapFrom(x => x.EmailAddress))
                .ForMember(x => x.Password, m => m.MapFrom(x => x.Password))
                .ForMember(x => x.Surname, m => m.MapFrom(x => x.Surname))
                .ForMember(x => x.UserName, m => m.MapFrom(x => x.Name + x.Surname.Substring(0, 4)));
               


             CreateMap<PersonDto, User>()
             .ForMember(e => e.Id, d => d.Ignore());



        }
    }
}
