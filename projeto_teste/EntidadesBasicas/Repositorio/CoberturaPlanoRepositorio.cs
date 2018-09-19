using System.Collections.Generic;
using System.Linq;
using EntidadesBasicas;
using Repositorio.Contracts;
using Repositorio.EF;

namespace Repositorio
{

    public class CoberturaPlanoRepositorio : ICoberturaPlanoRepository
    {

        private static readonly List<CoberturaPlano> CoberturaMemoriaDb = new List<CoberturaPlano>();


        public void inserir(CoberturaPlano cobertura)
        {
            using (var context = new CrudDbContext())
            {
                context.CoberturaPlano.Add(cobertura);
                context.SaveChanges();
            }

        }

        public void Deletar(CoberturaPlano entidade)
        {
            using (var context = new CrudDbContext())
            {
                context.CoberturaPlano.Remove(entidade);
                context.SaveChanges();
            }
        }

        public void Deletar(int id)
        {
            var coberturaPlano = new CoberturaPlano()
            {
                Id = id
            };
            using (var context = new CrudDbContext())
            {
                context.CoberturaPlano.Remove(coberturaPlano);
                context.SaveChanges();
            }
        }

        public List<CoberturaPlano> ConsultarTodos()
        {
            List<CoberturaPlano> consultarCoberturas;

            using (var context = new CrudDbContext())
            {
                consultarCoberturas = context.CoberturaPlano.ToList();
            }

            return consultarCoberturas;
        }

        public void Atualizar(CoberturaPlano entidade)
        {
            using (var context = new CrudDbContext())
            {
                context.CoberturaPlano.Update(entidade);
                context.SaveChanges();
            }
        }

    }
}
