using AutoMapper;
using LibraryT.Domain;
using LibraryT.Services.BookService.Dto;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryT.Services.BookService
{
    public class BookMapProfile:Profile
    {
        public BookMapProfile()
        {
            CreateMap<BookDto, Book>()
                .ForMember(x => x.Category, m => m.Ignore())
                .ForMember(x => x.Author, y => y.MapFrom(e=> e.Authors != null ? JsonConvert.SerializeObject(e.Authors):null))
                .ForMember(x => x.Id, m => m.Ignore());

            CreateMap<Book, BookDto>()
                .ForMember(x => x.CategoryId, e => e.MapFrom(x => x.Category != null ? x.Category.Id : (Guid?)null))
                .ForMember(x => x.Authors, y => y.MapFrom(e => e.Author != null ? JsonConvert.DeserializeObject<List<string>>(e.Author):null));
        }
    }
}
