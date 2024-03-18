using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using LibraryT.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryT.Services.CategoryService.Dto
{
    [AutoMapFrom(typeof(Category))]
    public class CategoryDto: EntityDto<Guid>
    {
        public string Name { get; set; }

        public Guid ShelfId { get; set; }
    }
}
