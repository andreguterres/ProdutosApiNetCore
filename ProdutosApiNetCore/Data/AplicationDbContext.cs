using Microsoft.EntityFrameworkCore;
using ProdutosApiNetCore.Entity;
using System.Collections.Generic;

namespace ProdutosApiNetCore.Data
{
    public class AplicationDbContext : DbContext
    {

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    IConfiguration configuration = new ConfigurationBuilder()
        //        .SetBasePath(Directory.GetCurrentDirectory())
        //        .AddJsonFile("appsettings.json", false, true)
        //        .Build();
        //    optionsBuilder.UseSqlServer(configuration.GetConnectionString("Serverconnection"));
        //}

        public AplicationDbContext (DbContextOptions<AplicationDbContext> options): base(options)
        {
        
        }
        public DbSet<Pedido> Pedidos { get; set; }

        public DbSet<ItensPedido> ItensPedidos { get; set; }
    }
      

    
}
