using AutoMapper;
using LibraryT.Domain;
using LibraryT.Services.AppConfigurationService.Dto;
using LibraryT.Services.ShelfService.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twilio.Rest.Api.V2010.Account.Sip.Domain.AuthTypes.AuthTypeCalls;

namespace LibraryT.Services.AppConfigurationService
{
    public class AppConfigurationMapProfile:Profile
    {
        public AppConfigurationMapProfile()
        {
            CreateMap<AppConfiguration, AppConfigurationDto>().ReverseMap();
        }
    }
}
