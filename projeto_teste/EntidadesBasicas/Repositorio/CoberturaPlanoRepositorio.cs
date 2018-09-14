using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesBasicas;
using Repositorio.EF;

namespace Repositorio
{
    public class CoberturaPlanoRepositorio
    {
       private static readonly List<CoberturaPlano> CoberturaMemoriaDb = new List<CoberturaPlano>();

        public void Inserir (CoberturaPlano cobertura)
        {
            using (var context = new CrudDbContext())
            {
                context.CoberturaPlano.Add(cobertura);
                context.SaveChanges();
            }
            
        }

        public List<CoberturaPlano> ConsultarCoberturas()
        {
            List<CoberturaPlano> consultarCoberturas;

            using (var context = new CrudDbContext())
            {
                consultarCoberturas = context.CoberturaPlano.ToList();
            }

            return consultarCoberturas;
        }


    }
}
