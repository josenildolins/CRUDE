using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesBasicas
{
    public class Plano
    {
        public int IdPlano { get; set; }
        public int IdCobertura { get; set; }
        public  CoberturaPlano Cobertura { get; set; }
        public int IdClassificacaoPlano { get; set; }
        public  ClassificacaoPlano ClassificacaoPlano { get; set; }
        public string Nome { get; set; }
        public string CodigoAns { get; set; }

    }
}
