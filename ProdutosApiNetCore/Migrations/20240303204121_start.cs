using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProdutosApiNetCore.Migrations
{
    /// <inheritdoc />
    public partial class start : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ItensPedidos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Quantidade = table.Column<int>(type: "INTEGER", nullable: false),
                    ValorNumerico = table.Column<decimal>(type: "TEXT", nullable: false),
                    Desconto = table.Column<decimal>(type: "TEXT", nullable: false),
                    DescricaoItem = table.Column<string>(type: "TEXT", nullable: true),
                    NumeroPedido = table.Column<int>(type: "INTEGER", nullable: false),
                    NomeFornecedor = table.Column<string>(type: "TEXT", nullable: true),
                    ValorTotal = table.Column<decimal>(type: "TEXT", nullable: false),
                    DescontoGeral = table.Column<int>(type: "INTEGER", nullable: false),
                    ValorLiquido = table.Column<int>(type: "INTEGER", nullable: false),
                    ValorUnitario = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItensPedidos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pedidos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NomeFornecedor = table.Column<string>(type: "TEXT", nullable: true),
                    DescontoGeral = table.Column<decimal>(type: "TEXT", nullable: false),
                    ItensId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedidos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pedidos_ItensPedidos_ItensId",
                        column: x => x.ItensId,
                        principalTable: "ItensPedidos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_ItensId",
                table: "Pedidos",
                column: "ItensId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pedidos");

            migrationBuilder.DropTable(
                name: "ItensPedidos");
        }
    }
}
