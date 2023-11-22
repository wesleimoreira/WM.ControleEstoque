using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WM.ControleEstoque.Api.Migrations
{
    public partial class QuartoMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CompraProdutos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProdutoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FornecedorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    QuantidadeCompra = table.Column<int>(type: "int", nullable: false),
                    DataDaCompra = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ValorTotalCompra = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompraProdutos", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompraProdutos");
        }
    }
}
