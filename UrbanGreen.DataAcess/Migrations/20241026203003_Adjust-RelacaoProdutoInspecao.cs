using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UrbanGreen.DataAcess.Migrations
{
    /// <inheritdoc />
    public partial class AdjustRelacaoProdutoInspecao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Inspecoes_ProdutoId",
                table: "Inspecoes");

            migrationBuilder.AddColumn<bool>(
                name: "Ativa",
                table: "Inspecoes",
                type: "bit",
                nullable: false,
                defaultValue: true);

            migrationBuilder.CreateIndex(
                name: "IX_Inspecoes_ProdutoId",
                table: "Inspecoes",
                column: "ProdutoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Inspecoes_ProdutoId",
                table: "Inspecoes");

            migrationBuilder.DropColumn(
                name: "Ativa",
                table: "Inspecoes");

            migrationBuilder.CreateIndex(
                name: "IX_Inspecoes_ProdutoId",
                table: "Inspecoes",
                column: "ProdutoId",
                unique: true);
        }
    }
}
