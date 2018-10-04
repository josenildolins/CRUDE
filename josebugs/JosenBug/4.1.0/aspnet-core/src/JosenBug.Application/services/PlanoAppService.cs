using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using Abp.Json;
using JosenBug.Contracts;
using JosenBug.Dto;
using Microsoft.EntityFrameworkCore;

namespace JosenBug.services
{
    public class PlanoAppService : JosenBugAppServiceBase, IPlanoAppService
    {
        private readonly IRepository<Plano.Plano> _planoRepository;

        public PlanoAppService(IRepository<Plano.Plano> planoRepository)
        {
            _planoRepository = planoRepository;
        }


        public async Task<int> InserirPlano(PlanoInputDto input)
        {
            Plano.Plano plan = new Plano.Plano();
            plan.IDCobertura = input.IdCobertura;
            plan.IDClassificacaoPlano = input.IdClassificacao;
            plan.Nome = input.Nome;
            plan.CodigoANS = input.CodigoAns;

            return await _planoRepository.InsertAndGetIdAsync(plan);
        }

        public async Task<IList<Plano.Plano>> ConsultarPlanos()
        {

            return await _planoRepository.GetAllIncluding(p => p.Classificacao)
                 .Include(p => p.Cobertura)
                 .ToListAsync();

        }

        public async Task<IList<Plano.Plano>> ListarPlanoPorNome(string nome)
        {
            return await _planoRepository.GetAll().Where(p => p.Nome.Contains(nome)).ToListAsync();
        }

        public async Task<IList<Plano.Plano>> ConsultarPlanoPorCobertura(int cobertura)
        {
            return await _planoRepository.GetAll().Where(p => p.IDCobertura.Equals(cobertura)).ToListAsync();
        }

        public async Task DeletarPlano(int id)
        {
            await _planoRepository.DeleteAsync(id);
        }
    }
}
