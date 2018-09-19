using System.Collections.Generic;
using System.Linq;
using EntidadesBasicas;
using Repositorio.Contracts;
using Repositorio.EF;


namespace Repositorio
{


    public class ClassificacaoPlanoRepositorio : IClassificacaoRepository
    {
        private static readonly List<ClassificacaoPlano> CadastroClassificacao = new List<ClassificacaoPlano>();


        public void inserir(ClassificacaoPlano entidade)
        {
            using (var context = new CrudDbContext())
            {
                context.ClassificacaoPlano.Add(entidade);
                context.SaveChanges();
            }
        }

        public void Deletar(ClassificacaoPlano entidade)
        {
            using (var context = new CrudDbContext())
            {
                context.ClassificacaoPlano.Remove(entidade);
            }
        }

        public void Deletar(int id)
        {
            var classificacao = new ClassificacaoPlano()
            {
                Id = id
            };
            using (var context = new CrudDbContext())
            {
                context.ClassificacaoPlano.Remove(classificacao);
                context.SaveChanges();


            }
        }

        public List<ClassificacaoPlano> ConsultarTodos()
        {

            List<ClassificacaoPlano> classificacao;
            using (var context = new CrudDbContext())
            {
                classificacao = context.ClassificacaoPlano.ToList();

            }
            return classificacao;
        }

        public void Atualizar(ClassificacaoPlano entidade)
        {
            using (var context = new CrudDbContext())
            {
                context.ClassificacaoPlano.Remove(entidade);
                context.SaveChanges();
            }
        }

        public List<ClassificacaoPlano> ConsultarClassificacao()
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



