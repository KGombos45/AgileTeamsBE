using Microsoft.EntityFrameworkCore.Migrations;

namespace BugTrackerData.Migrations
{
    public partial class datetodatetime6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicationUsersAndRoles");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "ApplicationUserRoles",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "ApplicationUserRoles",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "ApplicationUserRoles");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "ApplicationUserRoles");

            migrationBuilder.CreateTable(
                name: "ApplicationUsersAndRoles",
                columns: table => new
                {
                    ID = table.Column<string>(nullable: false),
                    About = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Role = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    UserName = table.Column<string>(nullable: true),
                    Zip = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUsersAndRoles", x => x.ID);
                });
        }
    }
}
