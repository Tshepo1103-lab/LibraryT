using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Entities;
using LibraryT.Authorization.Users;
using LibraryT.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryT.Services.ReviewsService.Dto
{
   //[AutoMapFrom(typeof(Review))]
    public class ReviewDto:EntityDto<Guid>
    {
        public int Rating { get; set; }
        public string Comment { get; set; }
        public Guid BookId { get; set; }
        public Guid UserId { get; set; }
    }
}
