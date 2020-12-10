using Microsoft.EntityFrameworkCore.Migrations;

namespace BugTrackerData.Migrations
{
    public partial class updatedTicket2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_AspNetUsers_UserId",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "TicketOwner",
                table: "Tickets");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Tickets",
                newName: "TicketOwnerId");

            migrationBuilder.RenameIndex(
                name: "IX_Tickets_UserId",
                table: "Tickets",
                newName: "IX_Tickets_TicketOwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_AspNetUsers_TicketOwnerId",
                table: "Tickets",
                column: "TicketOwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_AspNetUsers_TicketOwnerId",
                table: "Tickets");

            migrationBuilder.RenameColumn(
                name: "TicketOwnerId",
                table: "Tickets",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Tickets_TicketOwnerId",
                table: "Tickets",
                newName: "IX_Tickets_UserId");

            migrationBuilder.AddColumn<string>(
                name: "TicketOwner",
                table: "Tickets",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_AspNetUsers_UserId",
                table: "Tickets",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
