using Microsoft.EntityFrameworkCore.Migrations;

namespace LES.Migrations
{
    public partial class att_carinho : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CLI_CRR",
                table: "CLIENTES");

            migrationBuilder.AddForeignKey(
                name: "FK_CLI_CRR",
                table: "CLIENTES",
                column: "cli_crr_id",
                principalTable: "CARRINHOS",
                principalColumn: "crr_id",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CLI_CRR",
                table: "CLIENTES");

            migrationBuilder.AddForeignKey(
                name: "FK_CLI_CRR",
                table: "CLIENTES",
                column: "cli_crr_id",
                principalTable: "CARRINHOS",
                principalColumn: "crr_id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
