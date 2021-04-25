using Microsoft.EntityFrameworkCore.Migrations;

namespace LES.Migrations
{
    public partial class correcoesPedido : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PED_PED",
                table: "PEDIDOS");

            migrationBuilder.AddColumn<int>(
                name: "ped_end_id",
                table: "PEDIDOS",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "lip_quantia",
                table: "LIVROS_PEDIDOS",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_PEDIDOS_ped_end_id",
                table: "PEDIDOS",
                column: "ped_end_id");

            migrationBuilder.AddForeignKey(
                name: "FK_PED_CLI",
                table: "PEDIDOS",
                column: "ped_cli_id",
                principalTable: "CLIENTES",
                principalColumn: "cli_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PED_END",
                table: "PEDIDOS",
                column: "ped_end_id",
                principalTable: "ENDERECOS",
                principalColumn: "end_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PED_CLI",
                table: "PEDIDOS");

            migrationBuilder.DropForeignKey(
                name: "FK_PED_END",
                table: "PEDIDOS");

            migrationBuilder.DropIndex(
                name: "IX_PEDIDOS_ped_end_id",
                table: "PEDIDOS");

            migrationBuilder.DropColumn(
                name: "ped_end_id",
                table: "PEDIDOS");

            migrationBuilder.DropColumn(
                name: "lip_quantia",
                table: "LIVROS_PEDIDOS");

            migrationBuilder.AddForeignKey(
                name: "FK_PED_PED",
                table: "PEDIDOS",
                column: "ped_cli_id",
                principalTable: "CLIENTES",
                principalColumn: "cli_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
