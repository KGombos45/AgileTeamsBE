using Microsoft.EntityFrameworkCore.Migrations;

namespace AgileTeamsData.Migrations
{
    public partial class AddProjectOwner3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_AspNetUsers_ProjectOwnerId",
                table: "Projects");

            migrationBuilder.RenameColumn(
                name: "ProjectOwnerId",
                table: "Projects",
                newName: "Id1");

            migrationBuilder.RenameIndex(
                name: "IX_Projects_ProjectOwnerId",
                table: "Projects",
                newName: "IX_Projects_Id1");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_AspNetUsers_Id1",
                table: "Projects",
                column: "Id1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_AspNetUsers_Id1",
                table: "Projects");

            migrationBuilder.RenameColumn(
                name: "Id1",
                table: "Projects",
                newName: "ProjectOwnerId");

            migrationBuilder.RenameIndex(
                name: "IX_Projects_Id1",
                table: "Projects",
                newName: "IX_Projects_ProjectOwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_AspNetUsers_ProjectOwnerId",
                table: "Projects",
                column: "ProjectOwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
