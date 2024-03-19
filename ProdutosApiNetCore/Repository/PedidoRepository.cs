using Microsoft.EntityFrameworkCore;
using ProdutosApiNetCore.Data;
using ProdutosApiNetCore.Entity;
using System.Linq;

namespace ProdutosApiNetCore.Repo
{
    public class PedidoRepository : IPedidos
    {
        private readonly AplicationDbContext _context;

        public PedidoRepository(AplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<Pedido>> Pesquisar()
        {
            return _context.Pedidos.Include(i => i.Itens).ToList();
        }

        public async Task<List<Pedido>> PesquisarPorId(int id)
        {
        
         return _context.Pedidos.Include(i => i.Itens).Where(x=> x.PedidoId == id).ToList();

        }

        public async Task<object> Adicionar(Pedido pedido)
        {
            int i = 0;
            var x = new Pedido();

            x.NomeFornecedor = pedido.NomeFornecedor?.ToUpper();
            x.DescontoGeralPedido = pedido.DescontoGeralPedido;


            foreach (var item in pedido.Itens)
            {               
                i++;
                var itens = pedido.Itens.Count();

                var valorTotal = item.ValorUnitarioItem * item.QuantidadeItem;
                var valPorcetagem = valorTotal * item.PorcentagemDescontoItem / 100;
                item.PorcentagemDescontoItem = item.PorcentagemDescontoItem;
                item.ValorTotalItem = valorTotal;
                item.ValorLiquidoItem = valorTotal - valPorcetagem;
                item.DescricaoItem = item.DescricaoItem?.ToUpper();
                item.ValorEconomizadoItem = item.ValorTotalItem - item.ValorLiquidoItem;
                x.ValorTotalPedido += item.ValorLiquidoItem;

                if (i >= itens )
                {
                    if (x.DescontoGeralPedido > 0)
                    {
                        var calculoPorcetagem = x.ValorTotalPedido * x.DescontoGeralPedido / 100;
                        x.DescontoPedido =  calculoPorcetagem;
                        x.ValorTotalPagar = x.ValorTotalPedido - calculoPorcetagem;
                    }
                    else
                    {
                        x.ValorTotalPagar = x.ValorTotalPedido;

                    }
                }

                x.Itens.Add(item);
            }

            _context.Pedidos.Add(x);
            await _context.SaveChangesAsync();
            return pedido;
        }
        public async Task<List<Pedido>> Deletar(int id)
        {
            var pedidoExluido = _context.Pedidos.Include(i => i.Itens).Where(x => x.PedidoId == id).First();

            _context.Pedidos.Remove(pedidoExluido);

            await _context.SaveChangesAsync();

            return await _context.Pedidos.ToListAsync();
        }

    }
}
