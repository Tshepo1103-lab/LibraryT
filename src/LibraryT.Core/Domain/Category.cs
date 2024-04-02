using Abp.Domain.Entities.Auditing;
using LibraryT.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryT.Domain
{
    public class Category:FullAuditedEntity<Guid>
    {
        public string Name { get; set; }

        public Shelf Shelf { get; set; }
    }
}
