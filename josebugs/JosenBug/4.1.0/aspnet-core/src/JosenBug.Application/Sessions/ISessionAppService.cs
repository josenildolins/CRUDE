using System.Threading.Tasks;
using Abp.Application.Services;
using JosenBug.Sessions.Dto;

namespace JosenBug.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
