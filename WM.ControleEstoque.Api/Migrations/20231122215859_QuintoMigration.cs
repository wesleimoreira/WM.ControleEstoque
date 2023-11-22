using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WM.ControleEstoque.Api.Migrations
{
    public partial class QuintoMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_CompraProdutos_FornecedorId",
                table: "CompraProdutos",
                column: "FornecedorId");

            migrationBuilder.AddForeignKey(
                name: "FK_CompraProdutos_Fornecedores_FornecedorId",
                table: "CompraProdutos",
                column: "FornecedorId",
                principalTable: "Fornecedores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompraProdutos_Fornecedores_FornecedorId",
                table: "CompraProdutos");

            migrationBuilder.DropIndex(
                name: "IX_CompraProdutos_FornecedorId",
                table: "CompraProdutos");
        }
    }
}
