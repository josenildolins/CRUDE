using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using JosenBug.Configuration.Dto;

namespace JosenBug.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : JosenBugAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
