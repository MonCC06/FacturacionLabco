using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FacturacionLabco_AccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class trabajador : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PrimerApellido",
                table: "trabajador",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SegundoApellido",
                table: "trabajador",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PrimerApellido",
                table: "trabajador");

            migrationBuilder.DropColumn(
                name: "SegundoApellido",
                table: "trabajador");
        }
    }
}
