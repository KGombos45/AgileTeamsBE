using Microsoft.EntityFrameworkCore.Migrations;

namespace BugTrackerData.Migrations
{
    public partial class updatedTicket4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Projects_ProjectId",
                table: "Tickets");

            migrationBuilder.RenameColumn(
                name: "ProjectId",
                table: "Tickets",
                newName: "TicketProjectProjectId");

            migrationBuilder.RenameIndex(
                name: "IX_Tickets_ProjectId",
                table: "Tickets",
                newName: "IX_Tickets_TicketProjectProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Projects_TicketProjectProjectId",
                table: "Tickets",
                column: "TicketProjectProjectId",
                principalTable: "Projects",
                principalColumn: "ProjectId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Projects_TicketProjectProjectId",
                table: "Tickets");

            migrationBuilder.RenameColumn(
                name: "TicketProjectProjectId",
                table: "Tickets",
                newName: "ProjectId");

            migrationBuilder.RenameIndex(
                name: "IX_Tickets_TicketProjectProjectId",
                table: "Tickets",
                newName: "IX_Tickets_ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Projects_ProjectId",
                table: "Tickets",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "ProjectId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
