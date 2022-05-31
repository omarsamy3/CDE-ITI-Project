using Microsoft.EntityFrameworkCore.Migrations;

namespace ITICDE.Migrations
{
    public partial class addView : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Files_Views_ViewId",
                table: "Files");

            migrationBuilder.DropIndex(
                name: "IX_Files_ViewId",
                table: "Files");

            migrationBuilder.DropColumn(
                name: "ViewId",
                table: "Files");

            migrationBuilder.CreateTable(
                name: "FileView",
                columns: table => new
                {
                    FilesId = table.Column<int>(type: "int", nullable: false),
                    ViewsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileView", x => new { x.FilesId, x.ViewsId });
                    table.ForeignKey(
                        name: "FK_FileView_Files_FilesId",
                        column: x => x.FilesId,
                        principalTable: "Files",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FileView_Views_ViewsId",
                        column: x => x.ViewsId,
                        principalTable: "Views",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FileView_ViewsId",
                table: "FileView",
                column: "ViewsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FileView");

            migrationBuilder.AddColumn<int>(
                name: "ViewId",
                table: "Files",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Files_ViewId",
                table: "Files",
                column: "ViewId");

            migrationBuilder.AddForeignKey(
                name: "FK_Files_Views_ViewId",
                table: "Files",
                column: "ViewId",
                principalTable: "Views",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
