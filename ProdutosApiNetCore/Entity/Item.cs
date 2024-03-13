using System.ComponentModel.DataAnnotations;

namespace ProdutosApiNetCore.Entity
{
    public class Item
    {

        public int ItemId { get; set; }
        public int Quantidade { get; set; }
        public decimal PorcentagemDescontoItem { get; set; }

        [StringLength(100, MinimumLength = 3, ErrorMessage = "Descrição deve ter entre 3 e 100 caracteres obrigatoriamente!")]
        public string? DescricaoItem { get; set; }
        public decimal ValorTotal { get; set; }
        public decimal ValorLiquido { get; set; }
        public decimal ValorEconomizadoItem { get; set; }
        public decimal ValorUnitario { get; set; }

    }
}
