using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryT.Domain
{
    public class Fine:FullAuditedEntity<Guid>
    {
        public decimal Amount {  get; set; }
        public string Status { get; set; }

        public Transaction Transaction { get; set; }
    }
}
