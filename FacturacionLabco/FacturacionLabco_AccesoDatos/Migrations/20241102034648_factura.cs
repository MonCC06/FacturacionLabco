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
            migrationBuilder.AddColumn<int>(
                name: "VehiculoID",
                table: "factura",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_factura_VehiculoID",
                table: "factura",
                column: "VehiculoID");

            migrationBuilder.AddForeignKey(
                name: "FK_factura_vehiculo_VehiculoID",
                table: "factura",
                column: "VehiculoID",
                principalTable: "vehiculo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_factura_vehiculo_VehiculoID",
                table: "factura");

            migrationBuilder.DropIndex(
                name: "IX_factura_VehiculoID",
                table: "factura");

            migrationBuilder.DropColumn(
                name: "VehiculoID",
                table: "factura");
        }
    }
}
