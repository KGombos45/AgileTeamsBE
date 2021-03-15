using Microsoft.EntityFrameworkCore.Migrations;

namespace AgileTeamsData.Migrations
{
    public partial class AddProjectOwner : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Owner",
                table: "Projects",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Owner",
                table: "Projects");
        }
    }
}
