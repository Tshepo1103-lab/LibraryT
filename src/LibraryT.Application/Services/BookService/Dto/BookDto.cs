using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Entities;
using LibraryT.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryT.Services.BookService.Dto
{
    [AutoMapFrom(typeof(Book))]
    public class BookDto: EntityDto<Guid>
    {
        public string ISBN { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<string> Authors { get; set; }
        public DateTime? PublishedDate { get; set; }
        public int? Quantity { get; set; }
        public string Url { get; set; }
        public int Count { get; set; }
        public Guid CategoryId { get; set; }
        
        public Category Category {  get; set; }
        
    }
}
