using ProdutosApiNetCore.Entity;
using System.ComponentModel.DataAnnotations;

namespace ProdutosApiNetCore.Dto
{
    public class PedidoDto
    {
        public string? NomeFornecedor { get; set; }
        public bool CpfCadastrado { get; set; }
        public ICollection<ItemDto> Itens { get; set; } = new List<ItemDto>();

    }
}




