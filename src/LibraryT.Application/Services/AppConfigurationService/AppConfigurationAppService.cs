using Abp.Application.Services;
using Abp.Domain.Repositories;
using LibraryT.Domain;
using LibraryT.Services.AppConfigurationService.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryT.Services.AppConfigurationService
{
    public class AppConfigurationAppService : AsyncCrudAppService<AppConfiguration, AppConfigurationDto, Guid>
    {
        public AppConfigurationAppService(IRepository<AppConfiguration, Guid> repository) : base(repository)
        {
        }

    }
}
