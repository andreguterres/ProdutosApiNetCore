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
        public async Task<List<Pedido>> Pesquisar()
        {
            return  _context.Pedidos.Include(i => i.Itens).ToList();

        }    

        public async Task<object> Adicionar(Pedido pedido)
        {
            var x = new Pedido();

            x.NomeFornecedor = pedido.NomeFornecedor?.ToUpper();
            x.PorcentagemDescontoClienteFidelidade = pedido.PorcentagemDescontoClienteFidelidade;

            foreach (var item in pedido.Itens)
            {
                var valorTotal = item.ValorUnitario * item.Quantidade;
                var valPorcetagem = valorTotal * item.PorcentagemDescontoItem / 100;
                item.PorcentagemDescontoItem = item.PorcentagemDescontoItem;
                item.ValorTotal = valorTotal;
                item.ValorLiquido = valorTotal - valPorcetagem;
                item.DescricaoItem = item.DescricaoItem?.ToUpper();
                item.ValorEconomizadoItem = item.ValorTotal - item.ValorLiquido;

                if (x.PorcentagemDescontoClienteFidelidade > 0)
                {
                    x.ValorTotalPedido += item.ValorLiquido * x.PorcentagemDescontoClienteFidelidade / 100;
                }
                else
                {
                    x.ValorTotalPedido += item.ValorLiquido;

                }
                x.Itens.Add(item);
            }

            _context.Pedidos.Add(x);
            await _context.SaveChangesAsync();
            return pedido;
        }
    }
}
