using Abp.Domain.Entities;

namespace JosenBug.Plano
{
    public class Plano : Entity
    {
        public Plano()
        {

        }
        public string Nome { get; set; }
        public int IDCobertura { get; set; }
        public int IDClassificacaoPlano { get; set; }
        public string CodigoANS { get; set; }
        public Classificacao Classificacao { get; set; }
        public Cobertura Cobertura { get; set; }



    }
}
