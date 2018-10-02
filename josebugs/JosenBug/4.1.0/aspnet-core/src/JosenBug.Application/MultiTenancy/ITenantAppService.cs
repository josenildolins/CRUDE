using Abp.Application.Services;
using Abp.Application.Services.Dto;
using JosenBug.MultiTenancy.Dto;

namespace JosenBug.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}
