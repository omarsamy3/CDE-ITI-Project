using Microsoft.EntityFrameworkCore.Migrations;

namespace ITICDE.Migrations
{
    public partial class Teamleader : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TeamLeaderId",
                table: "Teams",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TeamLeaderId",
                table: "Teams");
        }
    }
}
