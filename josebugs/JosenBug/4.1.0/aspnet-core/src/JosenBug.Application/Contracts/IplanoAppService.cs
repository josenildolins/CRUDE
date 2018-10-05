using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using JosenBug.Dto;
using JosenBug.Plano;

namespace JosenBug.Contracts
{
    public interface IPlanoAppService: IApplicationService
    {
        Task<int> InserirPlano(PlanoInputDto input);
        Task<IList<PlanoOutputDto>> ConsultarPlanos();
        Task<IList<PlanoOutputDto>> ListarPlanoPorNome(string nome);
        Task<IList<PlanoOutputDto>> ListarPlanoPorCobertura(int cobertura);
        Task DeletarPlano(int id);
        Task<IList<PlanoOutputDto>> ListarPlanoPorClassificacao(int classificacao);

    }
}
