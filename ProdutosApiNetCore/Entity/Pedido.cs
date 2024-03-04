﻿using System.ComponentModel.DataAnnotations;

namespace ProdutosApiNetCore.Entity
{
    public class Pedido
    {
        public int Id { get; set; }

        [MaxLength(200)]
        public string? NomeFornecedor { get; set; }
        public decimal DescontoGeral { get; set; }

        public ICollection<Item> Itens { get; set; }
        public class Item
        {

            public int Id { get; set; }
            public int Quantidade { get; set; }
            public decimal Desconto { get; set; }

            [MaxLength(100)]
            public string? DescricaoItem { get; set; }
            public int NumeroPedido { get; set; }
            public decimal ValorTotal { get; set; }
            public int ValorLiquido { get; set; }
            public int ValorUnitario { get; set; }
        }
    }
}

