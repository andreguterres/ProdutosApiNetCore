using AutoMapper.Configuration.Conventions;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace ProdutosApiNetCore.Dto
{
    public class ItemDto
    {
        public int QuantidadeItem { get; set; }
        public decimal PorcentagemDescontoItem { get; set; }

        [StringLength(100, MinimumLength = 3, ErrorMessage = "Descrição deve ter entre 3 e 100 caracteres obrigatoriamente!")]
        public string? DescricaoItem { get; set; }
        public int ValorUnitarioItem { get; set; }
    }
}
