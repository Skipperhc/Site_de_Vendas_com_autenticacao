using Microsoft.EntityFrameworkCore.Migrations;

namespace Site_de_Vendas_com_autenticacao.Migrations
{
    public partial class addasdasd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NomeComprador",
                table: "Compras",
                nullable: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NomeComprador",
                table: "Compras");
        }
    }
}
