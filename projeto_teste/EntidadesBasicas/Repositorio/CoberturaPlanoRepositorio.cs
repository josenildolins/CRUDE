using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesBasicas;

namespace Repositorio
{
    public class CoberturaPlanoRepositorio
    {
       private static readonly List<CoberturaPlano> CoberturaMemoriaDb = new List<CoberturaPlano>();

        public void Inserir (CoberturaPlano cobertura)
        {
            CoberturaMemoriaDb.Add(cobertura);
        }

        public List<CoberturaPlano> ConsultarCoberturas()
        {
            return CoberturaMemoriaDb;
        }


    }
}
