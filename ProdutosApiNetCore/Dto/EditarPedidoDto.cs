namespace ProdutosApiNetCore.Dto
{
    public class EditarPedidoDto
    {
        public int PedidoId { get; set; }

        //public string? NomeFornecedor { get; set; }
        //public decimal CpfCadastrado { get; set; }
        public List<EditarItemDto> Itens { get; set; } = new List<EditarItemDto>();
    }
}
