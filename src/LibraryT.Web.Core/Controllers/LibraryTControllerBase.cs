using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace LibraryT.Controllers
{
    public abstract class LibraryTControllerBase: AbpController
    {
        protected LibraryTControllerBase()
        {
            LocalizationSourceName = LibraryTConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
