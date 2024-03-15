using System.Threading.Tasks;
using Abp.Application.Services;
using LibraryT.Authorization.Accounts.Dto;

namespace LibraryT.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
