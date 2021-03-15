using Microsoft.EntityFrameworkCore.Migrations;

namespace AgileTeamsData.Migrations
{
    public partial class updatedTicket3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_ProjectTaskStatuses_StatusProjectStatusId",
                table: "Tickets");

            migrationBuilder.RenameColumn(
                name: "StatusProjectStatusId",
                table: "Tickets",
                newName: "TicketStatusProjectStatusId");

            migrationBuilder.RenameIndex(
                name: "IX_Tickets_StatusProjectStatusId",
                table: "Tickets",
                newName: "IX_Tickets_TicketStatusProjectStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_ProjectStatuses_TicketStatusProjectStatusId",
                table: "Tickets",
                column: "TicketStatusProjectStatusId",
                principalTable: "ProjectStatuses",
                principalColumn: "ProjectStatusId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_ProjectStatuses_TicketStatusProjectStatusId",
                table: "Tickets");

            migrationBuilder.RenameColumn(
                name: "TicketStatusProjectStatusId",
                table: "Tickets",
                newName: "StatusProjectStatusId");

            migrationBuilder.RenameIndex(
                name: "IX_Tickets_TicketStatusProjectStatusId",
                table: "Tickets",
                newName: "IX_Tickets_StatusProjectStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_ProjectTaskStatuses_StatusProjectStatusId",
                table: "Tickets",
                column: "StatusProjectStatusId",
                principalTable: "ProjectTaskStatuses",
                principalColumn: "ProjectStatusId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
