using System.ComponentModel.DataAnnotations;

namespace ProdutosApiNetCore.Dto
{
    public class ItemDto
    {
        public int Quantidade { get; set; }

        [StringLength(100, MinimumLength = 3, ErrorMessage = "Descrição deve ter entre 3 e 100 caracteres obrigatoriamente!")]
        public string? DescricaoItem { get; set; }
        public int ValorUnitario { get; set; }
    }
}
