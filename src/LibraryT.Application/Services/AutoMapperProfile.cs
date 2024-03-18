using AutoMapper;
using LibraryT.Domain;
using LibraryT.Services.CategoryService.Dto;
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


        }
    }
}
