using Microsoft.EntityFrameworkCore.Migrations;

namespace ITICDE.Migrations
{
    public partial class renameusercreatorteam : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teams_Users_UserId",
                table: "Teams");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Teams",
                newName: "CreatorUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Teams_UserId",
                table: "Teams",
                newName: "IX_Teams_CreatorUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_Users_CreatorUserId",
                table: "Teams",
                column: "CreatorUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teams_Users_CreatorUserId",
                table: "Teams");

            migrationBuilder.RenameColumn(
                name: "CreatorUserId",
                table: "Teams",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Teams_CreatorUserId",
                table: "Teams",
                newName: "IX_Teams_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_Users_UserId",
                table: "Teams",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }
    }
}
