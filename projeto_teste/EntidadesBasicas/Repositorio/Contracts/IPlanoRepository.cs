using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesBasicas;

namespace Repositorio.Contracts
{
    public interface IPlanoRepository : IRepository<Plano>
    {
        List<Plano> ConsultarPlanosPorCobertura(int idCobertura);

        List<Plano> ConsultarPlanosPorClassificacao(int idClassificacao);

        List<Plano> ConsultarPlanosPorNome(string nomePlano);
    }
}
