using Microsoft.EntityFrameworkCore.Migrations;

namespace ITICDE.Migrations
{
    public partial class TypeChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "Files",
                type: "nvarchar(32)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(32)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "Files",
                type: "nvarchar(32)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(32)",
                oldNullable: true);
        }
    }
}
