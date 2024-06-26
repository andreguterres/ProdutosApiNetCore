﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProdutosApiNetCore.Migrations
{
    /// <inheritdoc />
    public partial class inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pedidos",
                columns: table => new
                {
                    PedidoId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NomeFornecedor = table.Column<string>(type: "TEXT", maxLength: 200, nullable: true),
                    CpfCadastrado = table.Column<bool>(type: "INTEGER", nullable: false),
                    ValorTotalPedido = table.Column<decimal>(type: "TEXT", nullable: false),
                    DescontoPedido = table.Column<decimal>(type: "TEXT", nullable: false),
                    ValorTotalPagar = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedidos", x => x.PedidoId);
                });

            migrationBuilder.CreateTable(
                name: "Itens",
                columns: table => new
                {
                    ItemId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    QuantidadeItem = table.Column<int>(type: "INTEGER", nullable: false),
                    PorcentagemDescontoItem = table.Column<decimal>(type: "TEXT", nullable: false),
                    DescricaoItem = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    ValorTotalItem = table.Column<decimal>(type: "TEXT", nullable: false),
                    ValorLiquidoItem = table.Column<decimal>(type: "TEXT", nullable: false),
                    ValorEconomizadoItem = table.Column<decimal>(type: "TEXT", nullable: false),
                    ValorUnitarioItem = table.Column<decimal>(type: "TEXT", nullable: false),
                    PedidoId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Itens", x => x.ItemId);
                    table.ForeignKey(
                        name: "FK_Itens_Pedidos_PedidoId",
                        column: x => x.PedidoId,
                        principalTable: "Pedidos",
                        principalColumn: "PedidoId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Itens_PedidoId",
                table: "Itens",
                column: "PedidoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Itens");

            migrationBuilder.DropTable(
                name: "Pedidos");
        }
    }
}
