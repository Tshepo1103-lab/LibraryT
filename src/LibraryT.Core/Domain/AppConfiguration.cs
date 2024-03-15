using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryT.Domain
{
    public class AppConfiguration:FullAuditedEntity<Guid>
    {
       public string Name {  get; set; }
        public string WelcomeMessage {  get; set; }
        public string Address {  get; set; }
        public string PrimaryColor { get; set; }
        public string SecondaryColor { get; set;}

    }
}
