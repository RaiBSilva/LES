using Microsoft.EntityFrameworkCore.Migrations;

namespace LES.Migrations
{
    public partial class correcao1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CARTOES_CREDITO_CLIENTES_ClienteId",
                table: "CARTOES_CREDITO");

            migrationBuilder.DropForeignKey(
                name: "FK_ENDERECOS_CLIENTES_ClienteId",
                table: "ENDERECOS");

            migrationBuilder.RenameColumn(
                name: "ClienteId",
                table: "ENDERECOS",
                newName: "end_cli_id");

            migrationBuilder.RenameIndex(
                name: "IX_ENDERECOS_ClienteId",
                table: "ENDERECOS",
                newName: "IX_ENDERECOS_end_cli_id");

            migrationBuilder.AlterColumn<int>(
                name: "end_cli_id",
                table: "ENDERECOS",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ClienteId",
                table: "CARTOES_CREDITO",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CAR_CLI",
                table: "CARTOES_CREDITO",
                column: "ClienteId",
                principalTable: "CLIENTES",
                principalColumn: "cli_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_END_CLI",
                table: "ENDERECOS",
                column: "end_cli_id",
                principalTable: "CLIENTES",
                principalColumn: "cli_id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CAR_CLI",
                table: "CARTOES_CREDITO");

            migrationBuilder.DropForeignKey(
                name: "FK_END_CLI",
                table: "ENDERECOS");

            migrationBuilder.RenameColumn(
                name: "end_cli_id",
                table: "ENDERECOS",
                newName: "ClienteId");

            migrationBuilder.RenameIndex(
                name: "IX_ENDERECOS_end_cli_id",
                table: "ENDERECOS",
                newName: "IX_ENDERECOS_ClienteId");

            migrationBuilder.AlterColumn<int>(
                name: "ClienteId",
                table: "ENDERECOS",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ClienteId",
                table: "CARTOES_CREDITO",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_CARTOES_CREDITO_CLIENTES_ClienteId",
                table: "CARTOES_CREDITO",
                column: "ClienteId",
                principalTable: "CLIENTES",
                principalColumn: "cli_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ENDERECOS_CLIENTES_ClienteId",
                table: "ENDERECOS",
                column: "ClienteId",
                principalTable: "CLIENTES",
                principalColumn: "cli_id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
