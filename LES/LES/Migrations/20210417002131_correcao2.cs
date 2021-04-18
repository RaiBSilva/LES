using Microsoft.EntityFrameworkCore.Migrations;

namespace LES.Migrations
{
    public partial class correcao2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ClienteId",
                table: "CARTOES_CREDITO",
                newName: "car_cli_id");

            migrationBuilder.RenameIndex(
                name: "IX_CARTOES_CREDITO_ClienteId",
                table: "CARTOES_CREDITO",
                newName: "IX_CARTOES_CREDITO_car_cli_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "car_cli_id",
                table: "CARTOES_CREDITO",
                newName: "ClienteId");

            migrationBuilder.RenameIndex(
                name: "IX_CARTOES_CREDITO_car_cli_id",
                table: "CARTOES_CREDITO",
                newName: "IX_CARTOES_CREDITO_ClienteId");
        }
    }
}
