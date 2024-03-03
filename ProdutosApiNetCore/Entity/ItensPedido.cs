using System.ComponentModel.DataAnnotations;

namespace ProdutosApiNetCore.Entity
{
    public class ItensPedido
    {
        public int Id { get; set; }
        public int Quantidade { get; set; }
        public decimal ValorNumerico { get; set; }
        public decimal Desconto { get; set; }
        public string? DescricaoItem { get; set; }
        public int NumeroPedido { get; set; }
        public string? NomeFornecedor { get; set; }
        public decimal ValorTotal { get; set; }
        public int DescontoGeral { get; set; }
        public int ValorLiquido { get; set; }
        public int ValorUnitario { get; set; }
    }
}
