using ProdutosApiNetCore.Entity;

namespace ProdutosApiNetCore.Repo
{
    public interface IPedidos
    {
        Task <Pedido> Adicionar (Pedido pedido);
        Task <List<Pedido>> Pesquisar();
    }
}
