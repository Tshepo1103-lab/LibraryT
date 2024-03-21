using Abp.Domain.Entities.Auditing;
using LibraryT.Authorization.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryT.Domain
{
    public class Person : FullAuditedEntity<Guid>
    {
        public virtual string UserName {  get; set; }
        public virtual string Name { get; set; }
        public virtual string Surname {  get; set; }
        public virtual string Password { get; set;}
        public virtual string EmailAddress {  get; set; }
        public virtual string PhoneNumber { get; set; }
        public User User { get; set; }
        public virtual string[] RoleNames { get; set; }

    }
}
