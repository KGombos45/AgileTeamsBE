using Microsoft.EntityFrameworkCore.Migrations;

namespace AgileTeamsData.Migrations
{
    public partial class datetodatetime5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "ApplicationUserRoles");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ApplicationUserRoles",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "RoleName",
                table: "ApplicationUserRoles",
                newName: "Role");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ID",
                table: "ApplicationUserRoles",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "Role",
                table: "ApplicationUserRoles",
                newName: "RoleName");

            migrationBuilder.AddColumn<string>(
                name: "RoleId",
                table: "ApplicationUserRoles",
                nullable: true);
        }
    }
}
