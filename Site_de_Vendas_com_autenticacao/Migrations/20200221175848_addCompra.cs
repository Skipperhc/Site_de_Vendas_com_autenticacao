using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Site_de_Vendas_com_autenticacao.Migrations
{
    public partial class addCompra : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Compras",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PessoaId = table.Column<string>(nullable: true),
                    QtdIgressos = table.Column<int>(nullable: false),
                    EventoNome = table.Column<string>(nullable: true),
                    EventoPreco = table.Column<double>(nullable: false),
                    EventoData = table.Column<DateTime>(nullable: false),
                    CasaNome = table.Column<string>(nullable: true),
                    CasaEndereço = table.Column<string>(nullable: true),
                    GeneroNome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Compras", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Compras");
        }
    }
}
