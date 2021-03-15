using Microsoft.EntityFrameworkCore.Migrations;

namespace AgileTeamsData.Migrations
{
    public partial class updatedModels8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Projects_ProjectID",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_ProjectID",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "ProjectID",
                table: "Tickets");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProjectID",
                table: "Tickets",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_ProjectID",
                table: "Tickets",
                column: "ProjectID");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Projects_ProjectID",
                table: "Tickets",
                column: "ProjectID",
                principalTable: "Projects",
                principalColumn: "ProjectID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
