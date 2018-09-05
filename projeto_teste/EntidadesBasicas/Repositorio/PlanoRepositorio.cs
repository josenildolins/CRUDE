using System.Collections.Generic;
using System.Linq;
using EntidadesBasicas;

namespace Repositorio
{
    public class PlanoRepositorio
    {
        private static  readonly  List<Plano> planosMemoriaBD = new List<Plano>();

        public void Inserir(Plano plano)
        {
            planosMemoriaBD.Add(plano);
        }

        public void Deletar(int idPlano)
        {
            planosMemoriaBD.RemoveAll(plano => plano.Id == idPlano);
        }

        public Plano ObterPlanoPorId(int idPlano)
        {
            return planosMemoriaBD.FirstOrDefault(plano => plano.Id == idPlano);
        }

        public List<Plano> ConsultarPlanos()
        {
            return planosMemoriaBD;
        }

        public List<Plano> ConsultarPlanosPorNome(string nomePlano)
        {
            return planosMemoriaBD.Where(plano => plano.Nome.Contains(nomePlano)).ToList();
        }

        public List<Plano> ConsultarPlanosPorCobertura(int idCobertura)
        {
            return planosMemoriaBD.Where(plano => plano.IDCobertura == idCobertura).ToList();
        }

        public List<Plano> ConsultarPlanosPorClassificacao(int idClassificacao)
        {
            return planosMemoriaBD.Where(plano => plano.IDClassificacaoPlano == idClassificacao).ToList();
        }

        
    }
}