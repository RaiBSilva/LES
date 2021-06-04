using Microsoft.EntityFrameworkCore.Migrations;

namespace LES.Migrations
{
    public partial class correcao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_PEDIDOS_ped_ped_id",
                table: "PEDIDOS");

            migrationBuilder.RenameColumn(
                name: "ped_ped_id",
                table: "PEDIDOS",
                newName: "ped_cod_id");

            migrationBuilder.CreateIndex(
                name: "IX_PEDIDOS_ped_cod_id",
                table: "PEDIDOS",
                column: "ped_cod_id",
                unique: true,
                filter: "[ped_cod_id] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_PEDIDOS_ped_cod_id",
                table: "PEDIDOS");

            migrationBuilder.RenameColumn(
                name: "ped_cod_id",
                table: "PEDIDOS",
                newName: "ped_ped_id");

            migrationBuilder.CreateIndex(
                name: "IX_PEDIDOS_ped_ped_id",
                table: "PEDIDOS",
                column: "ped_ped_id",
                unique: true,
                filter: "[ped_ped_id] IS NOT NULL");
        }
    }
}
