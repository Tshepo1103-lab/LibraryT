using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using LibraryT.Authorization.Users;
using LibraryT.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryT.Services.TransactionService.Dto
{
    [AutoMapFrom(typeof(Transaction))]
    public class TransactionDto: EntityDto<Guid>
    {
        public DateTime CheckOutDate { get; set; }
        public DateTime DueDate { get; set; }

        public DateTime ReturnedDate { get; set; }

        public Guid BookId { get; set; }

        public Guid UserId { get; set; }
    }
}
