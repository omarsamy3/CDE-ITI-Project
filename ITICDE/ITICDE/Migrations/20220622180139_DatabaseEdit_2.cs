using Microsoft.EntityFrameworkCore.Migrations;

namespace ITICDE.Migrations
{
    public partial class DatabaseEdit_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AssignedatorUserId",
                table: "Tasks",
                newName: "AssignedatoUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AssignedatoUserId",
                table: "Tasks",
                newName: "AssignedatorUserId");
        }
    }
}
