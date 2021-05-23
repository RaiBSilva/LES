using Microsoft.EntityFrameworkCore.Migrations;

namespace LES.Migrations
{
    public partial class carrinhosScheduler : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "crr_job_key",
                table: "CARRINHOS",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "crr_job_key",
                table: "CARRINHOS");
        }
    }
}
