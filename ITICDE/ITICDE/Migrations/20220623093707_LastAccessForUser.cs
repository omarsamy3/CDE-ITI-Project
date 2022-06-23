using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ITICDE.Migrations
{
    public partial class LastAccessForUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastAccess",
                table: "Teams");

            migrationBuilder.AddColumn<DateTime>(
                name: "LastAccessTime",
                table: "Users",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastAccessTime",
                table: "Users");

            migrationBuilder.AddColumn<DateTime>(
                name: "LastAccess",
                table: "Teams",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
