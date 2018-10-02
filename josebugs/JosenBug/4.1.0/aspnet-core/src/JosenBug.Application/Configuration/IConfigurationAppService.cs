using System.Threading.Tasks;
using JosenBug.Configuration.Dto;

namespace JosenBug.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
