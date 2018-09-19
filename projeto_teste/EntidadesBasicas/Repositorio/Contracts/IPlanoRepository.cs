using System.Collections.Generic;
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
