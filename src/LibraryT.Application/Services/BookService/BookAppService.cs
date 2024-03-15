using Abp.Application.Services;
using Abp.Domain.Repositories;
using LibraryT.Domain;
using LibraryT.Services.BookService.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryT.Services.BookService
{
    public class BookAppService : AsyncCrudAppService<Book,BookDto, Guid>
    {
        public BookAppService(IRepository<Book, Guid> repository) : base(repository)
        {
        }
    }
}
