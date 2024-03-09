using System.ComponentModel.DataAnnotations;

namespace ProdutosApiNetCore.Entity
{
    public class Item
    {

        public int Id { get; set; }
        public int Quantidade { get; set; }
        public decimal Desconto { get; set; }

        [StringLength(100, MinimumLength = 3, ErrorMessage = "Descrição deve ter entre 3 e 100 caracteres obrigatoriamente!")]
        public string? DescricaoItem { get; set; }
        public decimal ValorTotal { get; set; }
        public int ValorLiquido { get; set; }
        public int ValorUnitario { get; set; }

    }
}
