using System.ComponentModel.DataAnnotations;

namespace ProdutosApiNetCore.Entity
{
    public class Pedido
    {
        public int PedidoId { get; set; }

        [StringLength(200, MinimumLength = 3, ErrorMessage = "Nome do Fornecedor deve ter entre 5 e 100 caracteres obrigatoriamente!")]
        public string? NomeFornecedor { get; set; }
        public decimal PorcentagemDescontoClienteFidelidade { get; set; }
        public ICollection<Item> Itens { get; set; } = new List<Item>();
        public decimal ValorTotalPedido { get; set; }
        public decimal DescontoPedido { get; set; }
        public decimal ValorTotalPagar { get; set; }


    }
}

