using Abp.AutoMapper;

namespace JosenBug.Dto
{
    [AutoMapTo(typeof(Plano.Plano))]
    public class PlanoOutputDto
    {
        //public int IdCobertura { get; set; }
        //public int IdClassificacao { get; set; }
        public string Nome { get; set; }
        public string CodigoAns { get; set; }
        public CoberturaOutputDto Cobertura { get; set; }
        public ClassificacaoOutputDto Classificacao { get; set; }
    }
}
