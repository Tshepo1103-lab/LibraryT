using System.Threading.Tasks;
using Abp.Application.Services;
using LibraryT.Sessions.Dto;

namespace LibraryT.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
