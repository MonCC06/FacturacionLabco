using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FacturacionLabco_AccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class detallenuevoatributos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FacturaID",
                table: "detalle",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_detalle_FacturaID",
                table: "detalle",
                column: "FacturaID");

            migrationBuilder.AddForeignKey(
                name: "FK_detalle_FacturaID",
                table: "detalle",
                column: "FacturaID",
                principalTable: "factura",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_detalle_factura_FacturaID",
                table: "detalle");

            migrationBuilder.DropIndex(
                name: "IX_detalle_FacturaID",
                table: "detalle");

            migrationBuilder.DropColumn(
                name: "FacturaID",
                table: "detalle");
        }
    }
}
