using Microsoft.EntityFrameworkCore.Migrations;

namespace BugTrackerData.Migrations
{
    public partial class updatedModels6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_WorkItems_TicketProjectID",
                table: "Tickets");

            migrationBuilder.RenameColumn(
                name: "TicketProjectID",
                table: "Tickets",
                newName: "TicketWorkItemID");

            migrationBuilder.RenameIndex(
                name: "IX_Tickets_TicketProjectID",
                table: "Tickets",
                newName: "IX_Tickets_TicketWorkItemID");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_WorkItems_TicketWorkItemID",
                table: "Tickets",
                column: "TicketWorkItemID",
                principalTable: "WorkItems",
                principalColumn: "WorkItemID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_WorkItems_TicketWorkItemID",
                table: "Tickets");

            migrationBuilder.RenameColumn(
                name: "TicketWorkItemID",
                table: "Tickets",
                newName: "TicketProjectID");

            migrationBuilder.RenameIndex(
                name: "IX_Tickets_TicketWorkItemID",
                table: "Tickets",
                newName: "IX_Tickets_TicketProjectID");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_WorkItems_TicketProjectID",
                table: "Tickets",
                column: "TicketProjectID",
                principalTable: "WorkItems",
                principalColumn: "WorkItemID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
