using System.Collections.Generic;

namespace Site_de_Vendas_com_autenticacao.Repositories.Interface {
    public interface IRepository<T> {
        T Buscar(int id);
        void Adicionar(T entidade);
        void Remover(T entidade);
        List<T> Listar();
        void Editar(T entidade);
    }
}