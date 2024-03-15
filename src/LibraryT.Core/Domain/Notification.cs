using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryT.Domain
{
    public class Notification:FullAuditedEntity<Guid>
    {
        public DateTime Datesent { get; set; }
        public string Content {  get; set; }
        public Transaction Transaction { get; set; }
    }
}
