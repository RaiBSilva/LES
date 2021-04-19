using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LES.Migrations
{
    public partial class DbEntrega2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ped_cup_id",
                table: "PEDIDOS",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CUPONS",
                columns: table => new
                {
                    cup_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cup_cli_id = table.Column<int>(type: "int", nullable: false),
                    cup_codigo = table.Column<int>(type: "int", nullable: false),
                    cup_valor = table.Column<double>(type: "float", nullable: false),
                    cup_dt_cadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    cup_inativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CUP", x => x.cup_id);
                    table.ForeignKey(
                        name: "FK_CUP_CLI",
                        column: x => x.cup_cli_id,
                        principalTable: "CLIENTES",
                        principalColumn: "cli_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PEDIDOS_ped_cup_id",
                table: "PEDIDOS",
                column: "ped_cup_id",
                unique: true,
                filter: "[ped_cup_id] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CUPONS_cup_cli_id",
                table: "CUPONS",
                column: "cup_cli_id");

            migrationBuilder.AddForeignKey(
                name: "FK_PED_CUP",
                table: "PEDIDOS",
                column: "ped_cup_id",
                principalTable: "CUPONS",
                principalColumn: "cup_id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PED_CUP",
                table: "PEDIDOS");

            migrationBuilder.DropTable(
                name: "CUPONS");

            migrationBuilder.DropIndex(
                name: "IX_PEDIDOS_ped_cup_id",
                table: "PEDIDOS");

            migrationBuilder.DropColumn(
                name: "ped_cup_id",
                table: "PEDIDOS");
        }
    }
}
