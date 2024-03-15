using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using LibraryT.EntityFrameworkCore;
using LibraryT.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace LibraryT.Web.Tests
{
    [DependsOn(
        typeof(LibraryTWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class LibraryTWebTestModule : AbpModule
    {
        public LibraryTWebTestModule(LibraryTEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(LibraryTWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(LibraryTWebMvcModule).Assembly);
        }
    }
}