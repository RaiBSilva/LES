using Microsoft.EntityFrameworkCore.Migrations;

namespace LES.Migrations
{
    public partial class destrocaCrl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CRL_CRR",
                table: "CARRINHOS_LIVROS");

            migrationBuilder.DropForeignKey(
                name: "FK_CRL_LIV",
                table: "CARRINHOS_LIVROS");

            migrationBuilder.AddForeignKey(
                name: "FK_CRL_CRR",
                table: "CARRINHOS_LIVROS",
                column: "crl_crr_id",
                principalTable: "CARRINHOS",
                principalColumn: "crr_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CRL_LIV",
                table: "CARRINHOS_LIVROS",
                column: "crl_liv_id",
                principalTable: "LIVROS",
                principalColumn: "liv_id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CRL_CRR",
                table: "CARRINHOS_LIVROS");

            migrationBuilder.DropForeignKey(
                name: "FK_CRL_LIV",
                table: "CARRINHOS_LIVROS");

            migrationBuilder.AddForeignKey(
                name: "FK_CRL_CRR",
                table: "CARRINHOS_LIVROS",
                column: "crl_liv_id",
                principalTable: "CARRINHOS",
                principalColumn: "crr_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CRL_LIV",
                table: "CARRINHOS_LIVROS",
                column: "crl_crr_id",
                principalTable: "LIVROS",
                principalColumn: "liv_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
