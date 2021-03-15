using Microsoft.EntityFrameworkCore.Migrations;

namespace AgileTeamsData.Migrations
{
    public partial class datetodatetime7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_AspNetUsers_TicketOwnerID",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkItems_AspNetUsers_WorkItemOwnerID",
                table: "WorkItems");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_ApplicationUserRoles_TicketOwnerID",
                table: "Tickets",
                column: "TicketOwnerID",
                principalTable: "ApplicationUserRoles",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkItems_ApplicationUserRoles_WorkItemOwnerID",
                table: "WorkItems",
                column: "WorkItemOwnerID",
                principalTable: "ApplicationUserRoles",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_ApplicationUserRoles_TicketOwnerID",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkItems_ApplicationUserRoles_WorkItemOwnerID",
                table: "WorkItems");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_AspNetUsers_TicketOwnerID",
                table: "Tickets",
                column: "TicketOwnerID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkItems_AspNetUsers_WorkItemOwnerID",
                table: "WorkItems",
                column: "WorkItemOwnerID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
