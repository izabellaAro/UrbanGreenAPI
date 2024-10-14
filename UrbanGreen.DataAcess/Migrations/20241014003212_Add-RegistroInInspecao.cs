using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UrbanGreen.DataAcess.Migrations
{
    /// <inheritdoc />
    public partial class AddRegistroInInspecao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Registro",
                table: "Inspecoes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Registro",
                table: "Inspecoes");
        }
    }
}
