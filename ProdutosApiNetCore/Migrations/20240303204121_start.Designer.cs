﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProdutosApiNetCore.Data;

#nullable disable

namespace ProdutosApiNetCore.Migrations
{
    [DbContext(typeof(AplicationDbContext))]
    [Migration("20240303204121_start")]
    partial class start
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.10");

            modelBuilder.Entity("ProdutosApiNetCore.Entity.ItensPedido", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Desconto")
                        .HasColumnType("TEXT");

                    b.Property<int>("DescontoGeral")
                        .HasColumnType("INTEGER");

                    b.Property<string>("DescricaoItem")
                        .HasColumnType("TEXT");

                    b.Property<string>("NomeFornecedor")
                        .HasColumnType("TEXT");

                    b.Property<int>("NumeroPedido")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Quantidade")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ValorLiquido")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("ValorNumerico")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("ValorTotal")
                        .HasColumnType("TEXT");

                    b.Property<int>("ValorUnitario")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("ItensPedidos");
                });

            modelBuilder.Entity("ProdutosApiNetCore.Entity.Pedido", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("DescontoGeral")
                        .HasColumnType("TEXT");

                    b.Property<int>("ItensId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("NomeFornecedor")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ItensId");

                    b.ToTable("Pedidos");
                });

            modelBuilder.Entity("ProdutosApiNetCore.Entity.Pedido", b =>
                {
                    b.HasOne("ProdutosApiNetCore.Entity.ItensPedido", "Itens")
                        .WithMany()
                        .HasForeignKey("ItensId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Itens");
                });
#pragma warning restore 612, 618
        }
    }
}
