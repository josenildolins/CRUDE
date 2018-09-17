namespace EntidadesBasicas
{
    public class Plano
    {
        public int Id { get; set; }

        public int IdCobertura { get; set; }

        public CoberturaPlano Cobertura { get; set; }

        public int IdClassificacaoPlano { get; set; }

        public ClassificacaoPlano ClassificacaoPlano { get; set; }

        public string Nome { get; set; }

        public string CodigoAns { get; set; }
    }
}
