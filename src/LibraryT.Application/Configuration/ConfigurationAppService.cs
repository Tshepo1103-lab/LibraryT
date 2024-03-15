using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using LibraryT.Configuration.Dto;

namespace LibraryT.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : LibraryTAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
