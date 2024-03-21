using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryT.Domain
{
    public class Book: FullAuditedEntity<Guid>
    {
        public string ISBN { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string[] Author { get; set; }
        public DateTime PublishedDate { get; set; }
        public int Quantity {  get; set; }
        public string Url { get; set; }
        public Category Category { get; set; }

    }
}
