using Microsoft.EntityFrameworkCore.Migrations;

namespace SitemaDePedidosAPI.Migrations
{
    public partial class CorrigirCampoCEP : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CEP",
                table: "Clientes",
                type: "CHAR(8)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "CHAR(2)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CEP",
                table: "Clientes",
                type: "CHAR(2)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "CHAR(8)");
        }
    }
}
