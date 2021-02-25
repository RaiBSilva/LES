using Microsoft.EntityFrameworkCore.Migrations;

namespace LES.Migrations
{
    public partial class testeModelo2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EMDERECOS_CIDADES_FK_END_CID",
                table: "EMDERECOS");

            migrationBuilder.DropForeignKey(
                name: "FK_EMDERECOS_CLIENTES_FK_CLI_END",
                table: "EMDERECOS");

            migrationBuilder.RenameTable(
                name: "EMDERECOS",
                newName: "ENDERECOS");

            migrationBuilder.RenameIndex(
                name: "IX_EMDERECOS_FK_END_CID",
                table: "ENDERECOS",
                newName: "IX_ENDERECOS_FK_END_CID");

            migrationBuilder.RenameIndex(
                name: "IX_EMDERECOS_FK_CLI_END",
                table: "ENDERECOS",
                newName: "IX_ENDERECOS_FK_CLI_END");

            migrationBuilder.AddForeignKey(
                name: "FK_ENDERECOS_CIDADES_FK_END_CID",
                table: "ENDERECOS",
                column: "FK_END_CID",
                principalTable: "CIDADES",
                principalColumn: "cid_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ENDERECOS_CLIENTES_FK_CLI_END",
                table: "ENDERECOS",
                column: "FK_CLI_END",
                principalTable: "CLIENTES",
                principalColumn: "cli_id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ENDERECOS_CIDADES_FK_END_CID",
                table: "ENDERECOS");

            migrationBuilder.DropForeignKey(
                name: "FK_ENDERECOS_CLIENTES_FK_CLI_END",
                table: "ENDERECOS");

            migrationBuilder.RenameTable(
                name: "ENDERECOS",
                newName: "EMDERECOS");

            migrationBuilder.RenameIndex(
                name: "IX_ENDERECOS_FK_END_CID",
                table: "EMDERECOS",
                newName: "IX_EMDERECOS_FK_END_CID");

            migrationBuilder.RenameIndex(
                name: "IX_ENDERECOS_FK_CLI_END",
                table: "EMDERECOS",
                newName: "IX_EMDERECOS_FK_CLI_END");

            migrationBuilder.AddForeignKey(
                name: "FK_EMDERECOS_CIDADES_FK_END_CID",
                table: "EMDERECOS",
                column: "FK_END_CID",
                principalTable: "CIDADES",
                principalColumn: "cid_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EMDERECOS_CLIENTES_FK_CLI_END",
                table: "EMDERECOS",
                column: "FK_CLI_END",
                principalTable: "CLIENTES",
                principalColumn: "cli_id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
