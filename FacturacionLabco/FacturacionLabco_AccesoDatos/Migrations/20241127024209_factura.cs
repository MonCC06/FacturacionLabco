using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FacturacionLabco_AccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class factura : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_factura_detalle_DetalleID",
                table: "factura");

            migrationBuilder.DropIndex(
                name: "IX_factura_DetalleID",
                table: "factura");

            migrationBuilder.DropColumn(
                name: "DetalleID",
                table: "factura");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DetalleID",
                table: "factura",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_factura_DetalleID",
                table: "factura",
                column: "DetalleID");

            migrationBuilder.AddForeignKey(
                name: "FK_factura_DetalleID",
                table: "factura",
                column: "DetalleID",
                principalTable: "detalle",
                principalColumn: "Id");
        }
    }
}
