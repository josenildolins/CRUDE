using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesBasicas
{
    public class Plano
    {
        private static int id = 1;
        public Plano()
        {
            this.Id = id++;
        }

        public int Id { get; set; }
        public int IDCobertura { get; set; }
        public int IDClassificacaoPlano { get; set; }
        public string Nome { get; set; }
        public string CodigoANS { get; set; }

    }
}
