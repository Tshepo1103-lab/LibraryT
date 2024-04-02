using AutoMapper;
using LibraryT.Domain;
using LibraryT.Services.ShelfService.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryT.Services.ShelfService
{
    public class ShelfMapProfile : Profile
    {
        public ShelfMapProfile()
        {
            CreateMap<Shelf, ShelfDto>().ReverseMap();
        }
    }
}
