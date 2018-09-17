using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using EntidadesBasicas;
using Repositorio.EF;


namespace Repositorio
{

    //TODO herdar de IRepository<T>
    public class ClassificacaoPlanoRepositorio
    {
        private static readonly List<ClassificacaoPlano> CadastroClassificacao = new List<ClassificacaoPlano>();

        public void CadastrarClassificao(ClassificacaoPlano classificacao)
        {
            using (var context = new CrudDbContext())
            {
                context.ClassificacaoPlano.Add(classificacao);
                context.SaveChanges();
            }
            
        }

        public List<ClassificacaoPlano> ConsultarClassificacoes()
        {
            List<ClassificacaoPlano> classificacao;
            using (var context = new CrudDbContext())
            {
                 classificacao = context.ClassificacaoPlano.ToList();

            }

            return classificacao;
        }

        
    }
}
