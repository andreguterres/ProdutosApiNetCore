using ProdutosApiNetCore.Dto;
using ProdutosApiNetCore.Entity;

namespace ProdutosApiNetCore.Repo
{
    public interface IPedidos
    {
        Task <object> Adicionar (Pedido pedido);
        Task <List<Pedido>> Pesquisar();
    }

}
