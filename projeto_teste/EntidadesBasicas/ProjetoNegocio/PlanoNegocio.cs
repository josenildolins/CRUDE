using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repositorio;
using EntidadesBasicas;
using Repositorio.Contracts;

namespace ProjetoNegocio
{
    public class PlanoNegocio
    {
        private readonly ClassificacaoPlanoRepositorio _classificacaoPlanoRepositorioClassificacao = new ClassificacaoPlanoRepositorio();
        private readonly IPlanoRepository _planoRepositorio;
        private readonly CoberturaPlanoRepositorio _coberturaRepositorio = new CoberturaPlanoRepositorio();

        public PlanoNegocio(IPlanoRepository planoRepositorio) {
            this._planoRepositorio = planoRepositorio;
        }

        #region Metodos relativos  a classificacao
        public void CadastrarClassificacaoPlano(ClassificacaoPlano classificacao)
        {
            _classificacaoPlanoRepositorioClassificacao.CadastrarClassificao(classificacao);
        }

        public List<ClassificacaoPlano> ConsultarClassificacoes()
        {
            return _classificacaoPlanoRepositorioClassificacao.ConsultarClassificacoes();
        }
        #endregion
        public List<Plano> ConsultarPlanosPorClassificacao(int idClassificacao)
        {
            return _planoRepositorio.ConsultarPlanosPorClassificacao(idClassificacao);
        }

        //Metodo comentado de exemplo
        //public List<Plano> ConsultarPlanosPorClassificacao(ClassificacaoPlanoEnum classificacao)
        //{

        //    var planos = _planoRepositorio.ConsultarPlanosPorClassificacao((int)classificacao);
        //    foreach (Plano plano in planos)
        //    {
        //        if (plano.IdClassificacaoPlano == (int)ClassificacaoPlanoEnum.Individual)
        //        {

        //        }
        //    }
        //}


        #region Métodos relativos a planos
        public List<Plano> ConsultarPlanos()
        {
            return this._planoRepositorio.ConsultarTodos();
        }

        public List<Plano> ConsultarPlanosPorNome(string nome)
        {
            return this._planoRepositorio.ConsultarPlanosPorNome(nome);
        }


        public void CadastrarPlano(Plano plano)
        {
            this._planoRepositorio.Inserir(plano);
        }

        public void Deletar(int id)
        {
            this._planoRepositorio.Deletar(id);
        }

        public List<Plano> ConsultarPlanosPorCobertura(int idCobertura)
        {
            return _planoRepositorio.ConsultarPlanosPorCobertura(idCobertura);
        }

        public void AlterarPlano(Plano plano)
        {
            this._planoRepositorio.Atualizar(plano);
        }
        #endregion

        #region Metodos Relativos a Cobertura

        public void CadastrarCobertura(CoberturaPlano cobertura)

        {
            this._coberturaRepositorio.Inserir(cobertura);
        }

        public List<CoberturaPlano> ConsultarCobertura()
        {
            return this._coberturaRepositorio.ConsultarCoberturas();
        }

        #endregion
    }
}
