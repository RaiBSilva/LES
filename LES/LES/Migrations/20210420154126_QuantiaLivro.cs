using Microsoft.EntityFrameworkCore.Migrations;

namespace LES.Migrations
{
    public partial class QuantiaLivro : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "crl_quantia",
                table: "CARRINHOS_LIVROS",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "crl_quantia",
                table: "CARRINHOS_LIVROS");
        }
    }
}
