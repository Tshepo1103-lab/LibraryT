using Abp.Domain.Entities.Auditing;
using LibraryT.Authorization.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryT.Domain
{
    public class Review:FullAuditedEntity<Guid>
    {
        public int Rating {  get; set; }
        public string Comment {  get; set; }
        public Book Book { get; set; }
        public User User { get; set; }

    }
}
