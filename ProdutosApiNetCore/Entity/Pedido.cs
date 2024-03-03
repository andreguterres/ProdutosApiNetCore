using System.ComponentModel.DataAnnotations;

namespace ProdutosApiNetCore.Entity
{
    public class Pedido
    {
        public int Id { get; set; }
        public string? NomeFornecedor { get; set; }
        public decimal DescontoGeral { get; set; }
        public ItensPedido Itens { get; set; }
    }
}
