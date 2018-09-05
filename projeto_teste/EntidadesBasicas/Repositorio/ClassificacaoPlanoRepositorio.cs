using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using EntidadesBasicas;


namespace Repositorio
{
    public class ClassificacaoPlanoRepositorio
    {
        private static readonly List<ClassificacaoPlano> CadastroClassificacao = new List<ClassificacaoPlano>();
        public void CadastrarClassificao(ClassificacaoPlano classificacao)
        {
            CadastroClassificacao.Add(classificacao);
        }

        public List<ClassificacaoPlano> ConsultarClassificacoes()
        {

            return CadastroClassificacao;
        }

        
    }
}
