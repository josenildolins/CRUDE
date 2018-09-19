using System.Collections.Generic;
using EntidadesBasicas;
using Repositorio.Contracts;

namespace ProjetoNegocio
{
    public class PlanoNegocio
    {
        private readonly IClassificacaoRepository _planoRepositorioClassificacao;
        private readonly IPlanoRepository _planoRepositorio;
        private readonly ICoberturaPlanoRepository _coberturaRepositorio;

        public PlanoNegocio(IPlanoRepository planoRepositorio,
            IClassificacaoRepository repositorioClassificacao,
            ICoberturaPlanoRepository coberturaRepositorio)
        {

            this._planoRepositorio = planoRepositorio;
            this._planoRepositorioClassificacao = repositorioClassificacao;
            this._coberturaRepositorio = coberturaRepositorio;

        }

        #region Metodos relativos  a classificacao
        public void CadastrarClassificacaoPlano(ClassificacaoPlano classificacao)
        {
            _planoRepositorioClassificacao.inserir(classificacao);
        }

        public List<ClassificacaoPlano> ConsultarClassificacoes()
        {
            return _planoRepositorioClassificacao.ConsultarTodos();
        }
        #endregion

        #region Métodos relativos a planos
        public List<Plano> ConsultarPlanos()
        {
            return this._planoRepositorio.ConsultarTodos();
        }

        public List<Plano> ConsultarPlanosPorNome(string nome)
        {
            return this._planoRepositorio.ConsultarPlanosPorNome(nome);
        }


        public void Inserir(Plano plano)
        {
            this._planoRepositorio.inserir(plano);

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

        public List<Plano> ConsultarPlanosPorClassificacao(int idClassificacao)
        {
            return _planoRepositorio.ConsultarPlanosPorClassificacao(idClassificacao);
        }
        #endregion

        #region Metodos Relativos a Cobertura

        public void CadastrarCobertura(CoberturaPlano cobertura)

        {
            this._coberturaRepositorio.inserir(cobertura);
        }

        public List<CoberturaPlano> ConsultarCobertura()
        {
            return this._coberturaRepositorio.ConsultarTodos();
        }

        #endregion

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

    }
}
