using System.Collections.Generic;

namespace Repositorio.Contracts {
    public interface IRepository<T> {

        void Inserir(T entidade);

        void Deletar(T entidade);

        void Deletar(int id);

        List<T> ConsultarTodos();

        void Atualizar(T entidade);
    }
}