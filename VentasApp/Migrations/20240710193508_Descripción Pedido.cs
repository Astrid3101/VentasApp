using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VentasApp.Migrations
{
    /// <inheritdoc />
    public partial class DescripciónPedido : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DescripcionPedido",
                table: "Pedidos",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DescripcionPedido",
                table: "Pedidos");
        }
    }
}
