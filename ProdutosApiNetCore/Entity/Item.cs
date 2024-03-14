using System.ComponentModel.DataAnnotations;

namespace ProdutosApiNetCore.Entity
{
    public class Item
    {

        public int ItemId { get; set; }
        public int QuantidadeItem { get; set; }
        public decimal PorcentagemDescontoItem { get; set; }

        [StringLength(100, MinimumLength = 3, ErrorMessage = "Descrição deve ter entre 3 e 100 caracteres obrigatoriamente!")]
        public string? DescricaoItem { get; set; }
        public decimal ValorTotalItem { get; set; }
        public decimal ValorLiquidoItem { get; set; }
        public decimal ValorEconomizadoItem { get; set; }
        public decimal ValorUnitarioItem { get; set; }

    }
}
