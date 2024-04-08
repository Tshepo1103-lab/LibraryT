using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using LibraryT.Authorization.Users;
using LibraryT.Domain;
using LibraryT.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryT.Services.TransactionService.Dto
{
    [AutoMap(typeof(Transaction))]
    public class TransactionDto: EntityDto<Guid>
    {
        public DateTime CheckOutDate { get; set; }
        public DateTime DueDate { get; set; }

        public RefListStatus status { get; set; }
        public DateTime ReturnedDate { get; set; }

        public Guid BookId { get; set; }

        public int UserId { get; set; }

        public Book book { get; set; }
        public User User {  get; set; }

    }
}
