using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryT.Domain
{
    public class Shelf:FullAuditedEntity<Guid>
    {
        public string Name {  get; set; }
    }
}
