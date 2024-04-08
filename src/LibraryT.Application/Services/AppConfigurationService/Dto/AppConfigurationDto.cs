using Abp.Application.Services.Dto;
using AutoMapper;
using LibraryT.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryT.Services.AppConfigurationService.Dto
{
    [AutoMap(typeof(AppConfiguration))]
    public class AppConfigurationDto: EntityDto<Guid>
    {
        public string Name { get; set; }
        public string WelcomeMessage { get; set; }
        public string Address { get; set; }
        public string PrimaryColor { get; set; }
        public string SecondaryColor { get; set; }
        public string EmailAddress { get; set; }
        public string Contact { get; set; }
        public string AboutMessage { get; set; }
    }
}
