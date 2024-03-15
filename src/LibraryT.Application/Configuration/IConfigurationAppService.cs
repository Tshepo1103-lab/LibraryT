using System.Threading.Tasks;
using LibraryT.Configuration.Dto;

namespace LibraryT.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
