using Microsoft.EntityFrameworkCore.Migrations;

namespace AgileTeamsData.Migrations
{
    public partial class updatedModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_AspNetUsers_ProjectOwnerId",
                table: "Projects");

            migrationBuilder.DropForeignKey(
                name: "FK_Projects_ProjectStatuses_ProjectStatusId",
                table: "Projects");

            migrationBuilder.RenameColumn(
                name: "ProjectStatusName",
                table: "ProjectStatuses",
                newName: "StatusName");

            migrationBuilder.RenameColumn(
                name: "ProjectStatusId",
                table: "ProjectStatuses",
                newName: "StatusID");

            migrationBuilder.RenameColumn(
                name: "ProjectStatusId",
                table: "Projects",
                newName: "ProjectStatusID");

            migrationBuilder.RenameColumn(
                name: "ProjectOwnerId",
                table: "Projects",
                newName: "ProjectOwnerID");

            migrationBuilder.RenameIndex(
                name: "IX_Projects_ProjectStatusId",
                table: "Projects",
                newName: "IX_Projects_ProjectStatusID");

            migrationBuilder.RenameIndex(
                name: "IX_Projects_ProjectOwnerId",
                table: "Projects",
                newName: "IX_Projects_ProjectOwnerID");

            migrationBuilder.AlterColumn<int>(
                name: "ProjectStatusID",
                table: "Projects",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_AspNetUsers_ProjectOwnerID",
                table: "Projects",
                column: "ProjectOwnerID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_ProjectStatuses_ProjectStatusID",
                table: "Projects",
                column: "ProjectStatusID",
                principalTable: "ProjectStatuses",
                principalColumn: "StatusID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_AspNetUsers_ProjectOwnerID",
                table: "Projects");

            migrationBuilder.DropForeignKey(
                name: "FK_Projects_ProjectStatuses_ProjectStatusID",
                table: "Projects");

            migrationBuilder.RenameColumn(
                name: "StatusName",
                table: "ProjectStatuses",
                newName: "ProjectStatusName");

            migrationBuilder.RenameColumn(
                name: "StatusID",
                table: "ProjectStatuses",
                newName: "ProjectStatusId");

            migrationBuilder.RenameColumn(
                name: "ProjectStatusID",
                table: "Projects",
                newName: "ProjectStatusId");

            migrationBuilder.RenameColumn(
                name: "ProjectOwnerID",
                table: "Projects",
                newName: "ProjectOwnerId");

            migrationBuilder.RenameIndex(
                name: "IX_Projects_ProjectStatusID",
                table: "Projects",
                newName: "IX_Projects_ProjectStatusId");

            migrationBuilder.RenameIndex(
                name: "IX_Projects_ProjectOwnerID",
                table: "Projects",
                newName: "IX_Projects_ProjectOwnerId");

            migrationBuilder.AlterColumn<int>(
                name: "ProjectStatusId",
                table: "Projects",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_AspNetUsers_ProjectOwnerId",
                table: "Projects",
                column: "ProjectOwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_ProjectStatuses_ProjectStatusId",
                table: "Projects",
                column: "ProjectStatusId",
                principalTable: "ProjectStatuses",
                principalColumn: "ProjectStatusId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
