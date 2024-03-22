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

            x.CpfCadastrado = pedido.CpfCadastrado;

            foreach (var item in pedido.Itens)
            {               
                i++;
                var itens = pedido.Itens.Count();

                var valorTotal = item.ValorUnitarioItem * item.QuantidadeItem;
                var valPorcetagem = x.CpfCadastrado is true ? valorTotal * item.PorcentagemDescontoItem / 100 : 0;
                item.PorcentagemDescontoItem = item.PorcentagemDescontoItem;
                item.ValorTotalItem = valorTotal;
                item.ValorLiquidoItem = x.CpfCadastrado is true ? valorTotal - valPorcetagem : valPorcetagem; 
                item.DescricaoItem = item.DescricaoItem?.ToUpper();
                item.ValorEconomizadoItem = x.CpfCadastrado is true ? item.ValorTotalItem - item.ValorLiquidoItem:0;
                x.ValorTotalPedido += valorTotal;

                x.DescontoPedido += item.ValorEconomizadoItem;

                if (i >= itens) 
                { 
                    
                x.DescontoPedido = x.CpfCadastrado is true ? x.ValorTotalPedido - x.DescontoPedido : 0 ;
                x.ValorTotalPagar = x.CpfCadastrado is true ? x.ValorTotalPedido - item.ValorLiquidoItem : x.ValorTotalPedido;

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

        public Task<List<Pedido>> Atualizar(Pedido pedido)
        {
            var pedidoEditar = _context.Pedidos.Include(i => i.Itens).Where(x => x.PedidoId == pedido.PedidoId).First();

            //foreach (var item in pedidoEditar)
            //{
            //    var x = _context.Pedidos.Include(i => i.Itens).ToArrayAsync();

            //}
  

            //var item = pedidoEditar.Itens.Where(x=> x.ItemId == id).First();

            //foreach (var item in pedido.Itens)
            //{
            //    pedidoEditar.Itens.
            //}

            throw new NotImplementedException();
        }
    }
}
