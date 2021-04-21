using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LES.Migrations
{
    public partial class correcoes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "liv_dt_lancamento",
                table: "LIVROS",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "liv_edicao",
                table: "LIVROS",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "liv_dt_lancamento",
                table: "LIVROS");

            migrationBuilder.DropColumn(
                name: "liv_edicao",
                table: "LIVROS");
        }
    }
}
