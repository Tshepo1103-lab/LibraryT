using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using LibraryT.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryT.Services.ShelfService.Dto
{
    //[AutoMapFrom(typeof(Shelf))]
    public class ShelfDto: EntityDto<Guid>
    {
        public string Name { get; set; }
    }
}
