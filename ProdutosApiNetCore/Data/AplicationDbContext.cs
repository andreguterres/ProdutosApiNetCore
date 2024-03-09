using Microsoft.EntityFrameworkCore;
using ProdutosApiNetCore.Entity;
using System.Collections.Generic;
using static ProdutosApiNetCore.Entity.Pedido;

namespace ProdutosApiNetCore.Data
{
    public class AplicationDbContext : DbContext
    {
        public AplicationDbContext (DbContextOptions<AplicationDbContext> options): base(options)
        {
        
        }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Item> Itens { get; set; }


    }



}
