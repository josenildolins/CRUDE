using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using Abp.ObjectMapping;
using JosenBug.Contracts;
using JosenBug.Dto;
using Microsoft.EntityFrameworkCore;

namespace JosenBug.services
{
    public class PlanoAppService : JosenBugAppServiceBase, IPlanoAppService
    {
        private readonly IRepository<Plano.Plano> _planoRepository;
        private readonly IObjectMapper _objectMapper;

        public PlanoAppService(IRepository<Plano.Plano> planoRepository, IObjectMapper objectMapper)
        {
            _planoRepository = planoRepository;
            _objectMapper = objectMapper;
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

        public async Task<IList<PlanoOutputDto>> ConsultarPlanos()
        {
            List<Plano.Plano> planos = await _planoRepository.GetAllIncluding(p => p.Classificacao)
                 .Include(p => p.Cobertura)
                 .ToListAsync();

            var planosDto = new List<PlanoOutputDto>();

            //_objectMapper.Map<Plano.Plano>(planosDto);

            foreach (var plano in planos)
            {
                planosDto.Add(new PlanoOutputDto()
                {
                    CodigoAns = plano.CodigoANS,
                    Nome = plano.Nome,
                    Cobertura = new CoberturaOutputDto()
                    {
                        Cobertura = plano.Cobertura.Nome
                    },
                    Classificacao = new ClassificacaoOutputDto()
                    {
                        Classificacao = plano.Classificacao.Nome
                    }

                });
            }


            return planosDto;
        }

        public async Task<IList<PlanoOutputDto>> ListarPlanoPorNome(string nome)
        {
            List<Plano.Plano> planos = await _planoRepository.GetAll()
                .Where(p => p.Nome.Contains(nome))
                .ToListAsync();

            var planosDto = new List<PlanoOutputDto>();

            foreach (var plano in planos)
            {
                planosDto.Add(new PlanoOutputDto());
            }

            return planosDto;
        }

        public async Task<IList<PlanoOutputDto>> ListarPlanoPorCobertura(int cobertura)
        {
            List<Plano.Plano> planos = await _planoRepository.GetAll()
                .Where(p => p.IDCobertura.Equals(cobertura))
                .ToListAsync();

            var planosDto = new List<PlanoOutputDto>();

            foreach (var plano in planos)
            {
                planosDto.Add(new PlanoOutputDto());

            }

            return planosDto;


        }

        public async Task DeletarPlano(int id)
        {
            await _planoRepository.DeleteAsync(id);
        }

        public async Task<IList<PlanoOutputDto>> ListarPlanoPorClassificacao(int classificacao)
        {
            List<Plano.Plano> planos = await _planoRepository.GetAll()
                .Where(p => p.IDClassificacaoPlano.Equals(classificacao))
                .ToListAsync();

            var planosDto = new List<PlanoOutputDto>();

            foreach (var plano in planos)
            {
                planosDto.Add(new PlanoOutputDto());

            }

            return planosDto;

        }
    }
}
