using System.ComponentModel.DataAnnotations;

namespace ProdutosApiNetCore.Dto
{
    public class EditarItemDto
    {
        public int ItemId { get; set; }
        public int QuantidadeItem { get; set; }
        public bool CpfCadastrado { get; set; }

        [StringLength(100, MinimumLength = 3, ErrorMessage = "Descrição deve ter entre 3 e 100 caracteres obrigatoriamente!")]
        public string? DescricaoItem { get; set; }
        public decimal ValorTotalItem { get; set; }
       
    }
}
