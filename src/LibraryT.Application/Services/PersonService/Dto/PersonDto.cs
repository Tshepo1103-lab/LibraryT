using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Entities;
using LibraryT.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryT.Services.PersonService.Dto
{
    [AutoMap(typeof(Person))]
    public class PersonDto: EntityDto<Guid>
    {
        public string UserName { get; set; }
        /// <summary>
        ///
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        ///
        /// </summary>
        public string Surname { get; set; }
        /// <summary>
        ///
        /// </summary>
        public string PhoneNumber { get; set; }
        /// <summary>
        ///
        /// </summary>
        public string EmailAddress { get; set; }
        /// <summary>
        ///
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        ///
        /// </summary>
     
        public string[] RoleNames { get; set; }
    }
}
