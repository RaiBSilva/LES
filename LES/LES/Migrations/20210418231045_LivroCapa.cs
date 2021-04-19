using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LES.Migrations
{
    public partial class LivroCapa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "liv_capa",
                table: "LIVROS",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "liv_capa",
                table: "LIVROS");
        }
    }
}
