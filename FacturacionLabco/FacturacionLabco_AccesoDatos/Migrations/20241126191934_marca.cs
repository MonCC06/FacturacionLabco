using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FacturacionLabco_AccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class marca : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_vehiculo_Marca_MarcaId",
                table: "vehiculo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Marca",
                table: "Marca");

            migrationBuilder.RenameTable(
                name: "Marca",
                newName: "marca");

            migrationBuilder.AddPrimaryKey(
                name: "PK_marca",
                table: "marca",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_vehiculo_marca_MarcaId",
                table: "vehiculo",
                column: "MarcaId",
                principalTable: "marca",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_vehiculo_marca_MarcaId",
                table: "vehiculo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_marca",
                table: "marca");

            migrationBuilder.RenameTable(
                name: "marca",
                newName: "Marca");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Marca",
                table: "Marca",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_vehiculo_Marca_MarcaId",
                table: "vehiculo",
                column: "MarcaId",
                principalTable: "Marca",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
