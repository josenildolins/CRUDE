using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using JosenBug.Roles.Dto;
using JosenBug.Users.Dto;

namespace JosenBug.Users
{
    public interface IUserAppService : IAsyncCrudAppService<UserDto, long, PagedResultRequestDto, CreateUserDto, UserDto>
    {
        Task<ListResultDto<RoleDto>> GetRoles();

        Task ChangeLanguage(ChangeUserLanguageDto input);
    }
}
