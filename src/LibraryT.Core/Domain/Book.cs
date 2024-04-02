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
        /// <summary>
        /// 
        /// </summary>
        public virtual string ISBN { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual string Title { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual string Description { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual string Author { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? PublishedDate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual int? Quantity {  get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual string Url { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Category Category { get; set; } //

    }
}
