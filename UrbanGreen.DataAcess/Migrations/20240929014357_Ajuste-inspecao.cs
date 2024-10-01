using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UrbanGreen.DataAcess.Migrations
{
    /// <inheritdoc />
    public partial class Ajusteinspecao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Inspecoes_ProdutoId",
                table: "Inspecoes");

            migrationBuilder.DropColumn(
                name: "Colheita",
                table: "Inspecoes");

            migrationBuilder.DropColumn(
                name: "ControlePragas",
                table: "Inspecoes");

            migrationBuilder.DropColumn(
                name: "CuidadoSolo",
                table: "Inspecoes");

            migrationBuilder.DropColumn(
                name: "Irrigacao",
                table: "Inspecoes");

            migrationBuilder.DropColumn(
                name: "Registro",
                table: "Inspecoes");

            migrationBuilder.DropColumn(
                name: "SelecaoSemente",
                table: "Inspecoes");

            migrationBuilder.CreateTable(
                name: "TipoItemInspecao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoItemInspecao", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ItemInspecao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Realizado = table.Column<bool>(type: "bit", nullable: false),
                    TipoItemInspecaoId = table.Column<int>(type: "int", nullable: false),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InspecaoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemInspecao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemInspecao_Inspecoes_InspecaoId",
                        column: x => x.InspecaoId,
                        principalTable: "Inspecoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemInspecao_TipoItemInspecao_TipoItemInspecaoId",
                        column: x => x.TipoItemInspecaoId,
                        principalTable: "TipoItemInspecao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Inspecoes_ProdutoId",
                table: "Inspecoes",
                column: "ProdutoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ItemInspecao_InspecaoId",
                table: "ItemInspecao",
                column: "InspecaoId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemInspecao_TipoItemInspecaoId",
                table: "ItemInspecao",
                column: "TipoItemInspecaoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemInspecao");

            migrationBuilder.DropTable(
                name: "TipoItemInspecao");

            migrationBuilder.DropIndex(
                name: "IX_Inspecoes_ProdutoId",
                table: "Inspecoes");

            migrationBuilder.AddColumn<bool>(
                name: "Colheita",
                table: "Inspecoes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ControlePragas",
                table: "Inspecoes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "CuidadoSolo",
                table: "Inspecoes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Irrigacao",
                table: "Inspecoes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Registro",
                table: "Inspecoes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "SelecaoSemente",
                table: "Inspecoes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_Inspecoes_ProdutoId",
                table: "Inspecoes",
                column: "ProdutoId");
        }
    }
}
