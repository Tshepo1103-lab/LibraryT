using Abp.Domain.Entities.Auditing;
using LibraryT.Authorization.Users;
using LibraryT.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryT.Domain
{
    public class Transaction:FullAuditedEntity<Guid>
    {
        public RefListStatus Status { get; set; }
        public DateTime CheckOutDate { get; set; }
        public DateTime DueDate { get; set;}

        public DateTime ReturnedDate { get; set; }

        public Book Book { get; set; }

        public User User { get; set; }
    }
}
