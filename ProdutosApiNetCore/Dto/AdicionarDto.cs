using ProdutosApiNetCore.Entity;
using System.ComponentModel.DataAnnotations;

namespace ProdutosApiNetCore.Dto
{
    public class AdicionarDto
    {
        public string? NomeFornecedor { get; set; }
        public decimal DescontoGeralPedido { get; set; }
        public ICollection<ItemDto> Itens { get; set; } = new List<ItemDto>();

    }
}




