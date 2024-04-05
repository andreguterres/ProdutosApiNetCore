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
            Calculo(pedido);

            _context.Pedidos.Add(pedido);

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
            var x = new Pedido();

            object[] x; 

            var pedidoEditar = _context.Pedidos.Include(i => i.Itens).Where(x => x.PedidoId == pedido.PedidoId);
            var pedidoListaItens = _context.Pedidos.Include(i => i.Itens).Where(x => x.PedidoId == pedido.PedidoId).Select(i => i.Itens);

            //var listaItens = _context.Itens.Select(x => x.ItemId).ToList();
            var listaItens = pedidoEditar.SelectMany(i => i.Itens);

            foreach (var item in pedido.Itens)
            {

                foreach (var i in listaItens)
                {
                    if (item.ItemId == i.ItemId)
                    {
                        i.ValorUnitarioItem = item.ValorUnitarioItem ;
                    }
                }
                x.Itens.Add(item);
                //if (item.ItemId = listaItens.)
                //{

                //}


                //item.NomeFornecedor = pedido.NomeFornecedor != null ? item.NomeFornecedor : pedido.NomeFornecedor;


            }

            foreach (var listItens in pedido.Itens)
            {
                x.Itens.Add(listItens);
            }

            //foreach (var item in )
            //{

            //}



            //var item = pedidoEditar.Itens.Where(x=> x.ItemId == id).First();

            //foreach (var item in pedido.Itens)
            //{
            //    pedidoEditar.Itens.
            //}

            throw new NotImplementedException();
        }

        public void Calculo (Pedido pedido)
        {
            int i = 0;
            var x = new Pedido();

            pedido.NomeFornecedor = pedido.NomeFornecedor?.ToUpper();

            pedido.CpfCadastrado = pedido.CpfCadastrado;

            foreach (var item in pedido.Itens)
            {
                i++;
                var itens = pedido.Itens.Count();

                var valorTotal = item.ValorUnitarioItem * item.QuantidadeItem;
                var valPorcetagem = pedido.CpfCadastrado is true ? valorTotal * item.PorcentagemDescontoItem / 100 : 0;
                item.PorcentagemDescontoItem = item.PorcentagemDescontoItem;
                item.ValorTotalItem = valorTotal;
                item.ValorLiquidoItem = pedido.CpfCadastrado is true ? valorTotal - valPorcetagem : valPorcetagem;
                item.DescricaoItem = item.DescricaoItem?.ToUpper();
                item.ValorEconomizadoItem = pedido.CpfCadastrado is true ? item.ValorTotalItem - item.ValorLiquidoItem : 0;
                pedido.ValorTotalPedido += valorTotal;
                pedido.DescontoPedido += item.ValorEconomizadoItem;


                if (i >= itens)
                {
                    pedido.DescontoPedido = pedido.CpfCadastrado is true ? pedido.DescontoPedido : 0;

                    pedido.ValorTotalPagar = pedido.CpfCadastrado is true ? pedido.ValorTotalPedido - pedido.DescontoPedido : pedido.ValorTotalPedido;
                }

                x.Itens.Add(item);
            }

        }

    }
}
