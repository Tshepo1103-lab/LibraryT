using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryT.Services.FineService.Dto
{
    public class FineDto: EntityDto<Guid>
    {
        public decimal Amount { get; set; }
        public string Status { get; set; }

        public Guid TransactionId { get; set; }
    }
}
