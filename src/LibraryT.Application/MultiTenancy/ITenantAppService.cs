using Abp.Application.Services;
using LibraryT.MultiTenancy.Dto;

namespace LibraryT.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

