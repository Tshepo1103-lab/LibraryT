using AutoMapper;
using LibraryT.Domain;
using LibraryT.Services.ShelfService.Dto;
using LibraryT.Services.TransactionService.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryT.Services.TransactionService
{
    public class TransactionMapProfile : Profile
    {
        public TransactionMapProfile()
        {
            CreateMap<Transaction, TransactionDto>()
                .ForMember(x => x.BookId, e => e.MapFrom(x => x.Book.Id))
                .ForMember(x => x.UserId, e => e.MapFrom(x => x.User.Id))
                .ReverseMap();


            CreateMap<TransactionDto, Transaction>();
           
        }
    }

}
