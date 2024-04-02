using AutoMapper;
using LibraryT.Domain;
using LibraryT.Services.CategoryService.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryT.Services.CategoryService
{
    public class CategoryMapProfile:Profile
    {
        public CategoryMapProfile()
        {
            CreateMap<Category, CategoryDto>()
            .ForMember(x => x.ShelfId, e => e.MapFrom(x => x.Shelf.Id))
            .ReverseMap();
    }
    }
}
