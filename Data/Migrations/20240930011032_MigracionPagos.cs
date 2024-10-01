using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace urban_leo.Migrations
{
    /// <inheritdoc />
    public partial class MigracionPagos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "t_pago",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PaymentDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    NombreTarjeta = table.Column<string>(type: "text", nullable: true),
                    NumeroTarjeta = table.Column<string>(type: "text", nullable: true),
                    MontoTotal = table.Column<decimal>(type: "numeric", nullable: false),
                    UserID = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_pago", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "t_pedido",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserID = table.Column<string>(type: "text", nullable: true),
                    Total = table.Column<decimal>(type: "numeric", nullable: false),
                    pagoId = table.Column<int>(type: "integer", nullable: true),
                    Status = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_pedido", x => x.id);
                    table.ForeignKey(
                        name: "FK_t_pedido_t_pago_pagoId",
                        column: x => x.pagoId,
                        principalTable: "t_pago",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "t_detalle_pedido",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProductoId = table.Column<int>(type: "integer", nullable: true),
                    Cantidad = table.Column<int>(type: "integer", nullable: false),
                    Precio = table.Column<decimal>(type: "numeric", nullable: false),
                    pedidoID = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_detalle_pedido", x => x.id);
                    table.ForeignKey(
                        name: "FK_t_detalle_pedido_t_pedido_pedidoID",
                        column: x => x.pedidoID,
                        principalTable: "t_pedido",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_t_detalle_pedido_t_producto_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "t_producto",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_t_detalle_pedido_pedidoID",
                table: "t_detalle_pedido",
                column: "pedidoID");

            migrationBuilder.CreateIndex(
                name: "IX_t_detalle_pedido_ProductoId",
                table: "t_detalle_pedido",
                column: "ProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_t_pedido_pagoId",
                table: "t_pedido",
                column: "pagoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "t_detalle_pedido");

            migrationBuilder.DropTable(
                name: "t_pedido");

            migrationBuilder.DropTable(
                name: "t_pago");
        }
    }
}
