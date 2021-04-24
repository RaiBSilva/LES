using Microsoft.EntityFrameworkCore.Migrations;

namespace LES.Migrations
{
    public partial class cartaoPedidos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CARTOES_PEDIDOS",
                columns: table => new
                {
                    cap_car_id = table.Column<int>(type: "int", nullable: false),
                    cap_ped_id = table.Column<int>(type: "int", nullable: false),
                    cap_valor = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CAP", x => new { x.cap_car_id, x.cap_ped_id });
                    table.ForeignKey(
                        name: "FK_CAP_CAR",
                        column: x => x.cap_car_id,
                        principalTable: "CARTOES_CREDITO",
                        principalColumn: "car_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CAP_PED",
                        column: x => x.cap_ped_id,
                        principalTable: "PEDIDOS",
                        principalColumn: "ped_id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CARTOES_PEDIDOS_cap_ped_id",
                table: "CARTOES_PEDIDOS",
                column: "cap_ped_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CARTOES_PEDIDOS");
        }
    }
}
