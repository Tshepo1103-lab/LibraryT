using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryT.Domain
{
    public class TradingHour:FullAuditedEntity<Guid>
    {
        public string Weekdays {  get; set; }
        public string Satarday {  get; set; }
        public string Sunday {  get; set; }
    }
}
