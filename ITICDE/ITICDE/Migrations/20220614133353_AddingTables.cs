using Microsoft.EntityFrameworkCore.Migrations;

namespace ITICDE.Migrations
{
    public partial class AddingTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Files_Users_CreatorUserId",
                table: "Files");

            migrationBuilder.DropForeignKey(
                name: "FK_Folders_Users_CreatorUserId",
                table: "Folders");

            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Users_CreatorUserId1",
                table: "Projects");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Users_CreatorUserId1",
                table: "Tasks");

            migrationBuilder.DropForeignKey(
                name: "FK_Teams_Users_CreatorUserId1",
                table: "Teams");

            migrationBuilder.DropForeignKey(
                name: "FK_Views_Users_CreatorUserId",
                table: "Views");

            migrationBuilder.DropIndex(
                name: "IX_Views_CreatorUserId",
                table: "Views");

            migrationBuilder.DropIndex(
                name: "IX_Teams_CreatorUserId1",
                table: "Teams");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_CreatorUserId1",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Projects_CreatorUserId1",
                table: "Projects");

            migrationBuilder.DropIndex(
                name: "IX_Folders_CreatorUserId",
                table: "Folders");

            migrationBuilder.DropIndex(
                name: "IX_Files_CreatorUserId",
                table: "Files");

            migrationBuilder.DropColumn(
                name: "CreatorUserId",
                table: "Views");

            migrationBuilder.DropColumn(
                name: "CreatorUserId1",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "CreatorUserId1",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "CreatorUserId1",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "CreatorUserId",
                table: "Folders");

            migrationBuilder.DropColumn(
                name: "CreatorUserId",
                table: "Files");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Views",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "CreatorUserId",
                table: "Teams",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "CreatorUserId",
                table: "Tasks",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "CreatorUserId",
                table: "Projects",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Folders",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<bool>(
                name: "HasParent",
                table: "Folders",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Files",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Views_UserId",
                table: "Views",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_CreatorUserId",
                table: "Teams",
                column: "CreatorUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_CreatorUserId",
                table: "Tasks",
                column: "CreatorUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_CreatorUserId",
                table: "Projects",
                column: "CreatorUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Folders_UserId",
                table: "Folders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Files_UserId",
                table: "Files",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Files_Users_UserId",
                table: "Files",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Folders_Users_UserId",
                table: "Folders",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Users_CreatorUserId",
                table: "Projects",
                column: "CreatorUserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Users_CreatorUserId",
                table: "Tasks",
                column: "CreatorUserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_Users_CreatorUserId",
                table: "Teams",
                column: "CreatorUserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Views_Users_UserId",
                table: "Views",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Files_Users_UserId",
                table: "Files");

            migrationBuilder.DropForeignKey(
                name: "FK_Folders_Users_UserId",
                table: "Folders");

            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Users_CreatorUserId",
                table: "Projects");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Users_CreatorUserId",
                table: "Tasks");

            migrationBuilder.DropForeignKey(
                name: "FK_Teams_Users_CreatorUserId",
                table: "Teams");

            migrationBuilder.DropForeignKey(
                name: "FK_Views_Users_UserId",
                table: "Views");

            migrationBuilder.DropIndex(
                name: "IX_Views_UserId",
                table: "Views");

            migrationBuilder.DropIndex(
                name: "IX_Teams_CreatorUserId",
                table: "Teams");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_CreatorUserId",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Projects_CreatorUserId",
                table: "Projects");

            migrationBuilder.DropIndex(
                name: "IX_Folders_UserId",
                table: "Folders");

            migrationBuilder.DropIndex(
                name: "IX_Files_UserId",
                table: "Files");

            migrationBuilder.DropColumn(
                name: "HasParent",
                table: "Folders");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Views",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "CreatorUserId",
                table: "Views",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CreatorUserId",
                table: "Teams",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatorUserId1",
                table: "Teams",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CreatorUserId",
                table: "Tasks",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "CreatorUserId1",
                table: "Tasks",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CreatorUserId",
                table: "Projects",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatorUserId1",
                table: "Projects",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Folders",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "CreatorUserId",
                table: "Folders",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Files",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatorUserId",
                table: "Files",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Views_CreatorUserId",
                table: "Views",
                column: "CreatorUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_CreatorUserId1",
                table: "Teams",
                column: "CreatorUserId1");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_CreatorUserId1",
                table: "Tasks",
                column: "CreatorUserId1");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_CreatorUserId1",
                table: "Projects",
                column: "CreatorUserId1");

            migrationBuilder.CreateIndex(
                name: "IX_Folders_CreatorUserId",
                table: "Folders",
                column: "CreatorUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Files_CreatorUserId",
                table: "Files",
                column: "CreatorUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Files_Users_CreatorUserId",
                table: "Files",
                column: "CreatorUserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Folders_Users_CreatorUserId",
                table: "Folders",
                column: "CreatorUserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Users_CreatorUserId1",
                table: "Projects",
                column: "CreatorUserId1",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Users_CreatorUserId1",
                table: "Tasks",
                column: "CreatorUserId1",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_Users_CreatorUserId1",
                table: "Teams",
                column: "CreatorUserId1",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Views_Users_CreatorUserId",
                table: "Views",
                column: "CreatorUserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
