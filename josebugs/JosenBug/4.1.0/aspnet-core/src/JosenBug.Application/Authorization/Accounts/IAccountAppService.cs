using System.Threading.Tasks;
using Abp.Application.Services;
using JosenBug.Authorization.Accounts.Dto;

namespace JosenBug.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
