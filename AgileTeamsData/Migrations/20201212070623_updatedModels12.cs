using Microsoft.EntityFrameworkCore.Migrations;

namespace AgileTeamsData.Migrations
{
    public partial class updatedModels12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkItemComments_WorkItems_CommentWorkItemID",
                table: "WorkItemComments");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkItemComments_Tickets_TicketID",
                table: "WorkItemComments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WorkItemComments",
                table: "WorkItemComments");

            migrationBuilder.RenameTable(
                name: "WorkItemComments",
                newName: "WorkItemComment");

            migrationBuilder.RenameIndex(
                name: "IX_WorkItemComments_TicketID",
                table: "WorkItemComment",
                newName: "IX_WorkItemComment_TicketID");

            migrationBuilder.RenameIndex(
                name: "IX_WorkItemComments_CommentWorkItemID",
                table: "WorkItemComment",
                newName: "IX_WorkItemComment_CommentWorkItemID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WorkItemComment",
                table: "WorkItemComment",
                column: "CommentID");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkItemComment_WorkItems_CommentWorkItemID",
                table: "WorkItemComment",
                column: "CommentWorkItemID",
                principalTable: "WorkItems",
                principalColumn: "WorkItemID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkItemComment_Tickets_TicketID",
                table: "WorkItemComment",
                column: "TicketID",
                principalTable: "Tickets",
                principalColumn: "TicketID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkItemComment_WorkItems_CommentWorkItemID",
                table: "WorkItemComment");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkItemComment_Tickets_TicketID",
                table: "WorkItemComment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WorkItemComment",
                table: "WorkItemComment");

            migrationBuilder.RenameTable(
                name: "WorkItemComment",
                newName: "WorkItemComments");

            migrationBuilder.RenameIndex(
                name: "IX_WorkItemComment_TicketID",
                table: "WorkItemComments",
                newName: "IX_WorkItemComments_TicketID");

            migrationBuilder.RenameIndex(
                name: "IX_WorkItemComment_CommentWorkItemID",
                table: "WorkItemComments",
                newName: "IX_WorkItemComments_CommentWorkItemID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WorkItemComments",
                table: "WorkItemComments",
                column: "CommentID");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkItemComments_WorkItems_CommentWorkItemID",
                table: "WorkItemComments",
                column: "CommentWorkItemID",
                principalTable: "WorkItems",
                principalColumn: "WorkItemID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkItemComments_Tickets_TicketID",
                table: "WorkItemComments",
                column: "TicketID",
                principalTable: "Tickets",
                principalColumn: "TicketID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
