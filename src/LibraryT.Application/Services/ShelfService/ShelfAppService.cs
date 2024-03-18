using Abp.Application.Services;
using Abp.Domain.Repositories;
using LibraryT.Domain;
using LibraryT.Services.ShelfService.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryT.Services.ShelfService
{
    public class ShelfAppService : AsyncCrudAppService<Shelf, ShelfDto, Guid>
    {
        public ShelfAppService(IRepository<Shelf, Guid> repository) : base(repository)
        {
        }
    }
}
