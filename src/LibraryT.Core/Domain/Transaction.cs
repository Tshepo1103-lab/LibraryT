using Abp.Domain.Entities.Auditing;
using LibraryT.Authorization.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryT.Domain
{
    public class Transaction:FullAuditedEntity<Guid>
    {
        public DateTime CheckOutDate { get; set; }
        public DateTime DueDate { get; set;}

        public string ReturnedDate { get; set; }

        public Book Book { get; set; }

        public User User { get; set; }
    }
}
