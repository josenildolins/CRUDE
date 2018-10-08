using System.Threading.Tasks;
using Abp.Application.Services;
using JosenBug.Dto;

namespace JosenBug.Contracts
{
    public interface IClassificacaoAppService : IApplicationService
    {
        Task<ClassificacaoInputDto> InserirClassificacao();

    }
}
