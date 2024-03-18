using Abp.Application.Services;
using Abp.Domain.Repositories;
using LibraryT.Domain;
using LibraryT.Services.ReviewsService.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryT.Services.ReviewsService
{
    public class ReviewAppService : AsyncCrudAppService<Review, ReviewDto, Guid>
    {
        public ReviewAppService(IRepository<Review, Guid> repository) : base(repository)
        {
        }
    }
}
