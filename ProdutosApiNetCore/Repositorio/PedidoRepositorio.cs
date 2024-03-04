using Microsoft.EntityFrameworkCore;
using ProdutosApiNetCore.Data;
using ProdutosApiNetCore.Entity;

namespace ProdutosApiNetCore.Repo
{
    public class PedidoRepositorio : IPedidos
    {
        private readonly AplicationDbContext _context;

        public PedidoRepositorio(AplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Pedido> Adicionar(Pedido pedido)
        {
            _context.Pedidos.Add(pedido);
            await _context.SaveChangesAsync();
            return pedido;
        }

        public async Task<List<Pedido>> Pesquisar()
        {
            return  _context.Pedidos.Include(i => i.Itens).ToList();

        }
    }
}
