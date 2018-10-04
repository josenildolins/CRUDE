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
        Task<IList<Plano.Plano>> ConsultarPlanos();
        Task<IList<Plano.Plano>> ListarPlanoPorNome(string nome);
        Task<IList<Plano.Plano>> ConsultarPlanoPorCobertura(int cobertura);
        Task DeletarPlano(int id);
        
    }
}
