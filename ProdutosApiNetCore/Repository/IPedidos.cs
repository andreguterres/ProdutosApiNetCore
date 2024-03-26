using ProdutosApiNetCore.Dto;
using ProdutosApiNetCore.Entity;

namespace ProdutosApiNetCore.Repo
{
    public interface IPedidos
    {
        Task <object> Adicionar (Pedido pedido);
        Task <List<Pedido>> Pesquisar();
        Task <List<Pedido>> PesquisarPorId(int id);
        Task<List<Pedido>> Deletar(int id);
        Task<List<Pedido>> Atualizar(Pedido pedido);


    }

}
