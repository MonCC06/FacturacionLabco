using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FacturacionLabco.Migrations
{
    /// <inheritdoc />
    public partial class Cliente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "clientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cedula = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Correo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "marca",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre_Marca = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estado_Marca = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_marca", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "producto",
                columns: table => new
                {
                    Id_Producto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion_Producto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Precio_Producto = table.Column<float>(type: "real", nullable: false),
                    Estado_Producto = table.Column<bool>(type: "bit", nullable: false),
                    Stock_Producto = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_producto", x => x.Id_Producto);
                });

            migrationBuilder.CreateTable(
                name: "servicio",
                columns: table => new
                {
                    Id_Servicio = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion_Servicio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Precio_Servicio = table.Column<float>(type: "real", nullable: false),
                    Estado_Producto = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_servicio", x => x.Id_Servicio);
                });

            migrationBuilder.CreateTable(
                name: "trabajador",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cedula = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Correo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_trabajador", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "vehiculo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Modelo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Anno = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VIN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Placa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipoDeDistancia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DistanciaRecorrida = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IDCliente = table.Column<int>(type: "int", nullable: false),
                    IDMarca = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vehiculo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_vehiculo_clientes_IDCliente",
                        column: x => x.IDCliente,
                        principalTable: "clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_vehiculo_marca_IDMarca",
                        column: x => x.IDMarca,
                        principalTable: "marca",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "detalle",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Monto = table.Column<float>(type: "real", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    IDProducto = table.Column<int>(type: "int", nullable: false),
                    IDServicio = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_detalle", x => x.Id);
                    table.ForeignKey(
                        name: "FK_detalle_producto_IDProducto",
                        column: x => x.IDProducto,
                        principalTable: "producto",
                        principalColumn: "Id_Producto",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_detalle_servicio_IDServicio",
                        column: x => x.IDServicio,
                        principalTable: "servicio",
                        principalColumn: "Id_Servicio",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "factura",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Total = table.Column<float>(type: "real", nullable: false),
                    Subtotal = table.Column<float>(type: "real", nullable: false),
                    Iva = table.Column<float>(type: "real", nullable: false),
                    Descuento = table.Column<float>(type: "real", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IDDetalle = table.Column<int>(type: "int", nullable: false),
                    IDTrabajador = table.Column<int>(type: "int", nullable: false),
                    IDCliente = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_factura", x => x.Id);
                    table.ForeignKey(
                        name: "FK_factura_clientes_IDCliente",
                        column: x => x.IDCliente,
                        principalTable: "clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_factura_detalle_IDDetalle",
                        column: x => x.IDDetalle,
                        principalTable: "detalle",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_factura_trabajador_IDTrabajador",
                        column: x => x.IDTrabajador,
                        principalTable: "trabajador",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_detalle_IDProducto",
                table: "detalle",
                column: "IDProducto");

            migrationBuilder.CreateIndex(
                name: "IX_detalle_IDServicio",
                table: "detalle",
                column: "IDServicio");

            migrationBuilder.CreateIndex(
                name: "IX_factura_IDCliente",
                table: "factura",
                column: "IDCliente");

            migrationBuilder.CreateIndex(
                name: "IX_factura_IDDetalle",
                table: "factura",
                column: "IDDetalle");

            migrationBuilder.CreateIndex(
                name: "IX_factura_IDTrabajador",
                table: "factura",
                column: "IDTrabajador");

            migrationBuilder.CreateIndex(
                name: "IX_vehiculo_IDCliente",
                table: "vehiculo",
                column: "IDCliente");

            migrationBuilder.CreateIndex(
                name: "IX_vehiculo_IDMarca",
                table: "vehiculo",
                column: "IDMarca");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "factura");

            migrationBuilder.DropTable(
                name: "vehiculo");

            migrationBuilder.DropTable(
                name: "detalle");

            migrationBuilder.DropTable(
                name: "trabajador");

            migrationBuilder.DropTable(
                name: "clientes");

            migrationBuilder.DropTable(
                name: "marca");

            migrationBuilder.DropTable(
                name: "producto");

            migrationBuilder.DropTable(
                name: "servicio");
        }
    }
}
