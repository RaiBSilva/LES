using Microsoft.EntityFrameworkCore.Migrations;

namespace LES.Migrations
{
    public partial class CorrecaoTituloLivro : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Titulo",
                table: "LIVROS",
                newName: "liv_titulo");

            migrationBuilder.AlterColumn<string>(
                name: "liv_titulo",
                table: "LIVROS",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "liv_titulo",
                table: "LIVROS",
                newName: "Titulo");

            migrationBuilder.AlterColumn<string>(
                name: "Titulo",
                table: "LIVROS",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
