using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BugTrackerData.Migrations
{
    public partial class updatedModels10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TaskComments");

            migrationBuilder.AddColumn<int>(
                name: "WorkItemPriorityID",
                table: "WorkItems",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "WorkItemComment",
                columns: table => new
                {
                    CommentID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Comment = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    SubmittedBy = table.Column<string>(nullable: true),
                    SubmittedOn = table.Column<DateTime>(type: "Date", nullable: false),
                    Updated = table.Column<DateTime>(type: "Date", nullable: false),
                    CommentWorkItemID = table.Column<string>(nullable: true),
                    TicketID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkItemComment", x => x.CommentID);
                    table.ForeignKey(
                        name: "FK_WorkItemComment_WorkItems_CommentWorkItemID",
                        column: x => x.CommentWorkItemID,
                        principalTable: "WorkItems",
                        principalColumn: "WorkItemID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WorkItemComment_Tickets_TicketID",
                        column: x => x.TicketID,
                        principalTable: "Tickets",
                        principalColumn: "TicketID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WorkItems_WorkItemPriorityID",
                table: "WorkItems",
                column: "WorkItemPriorityID");

            migrationBuilder.CreateIndex(
                name: "IX_WorkItemComment_CommentWorkItemID",
                table: "WorkItemComment",
                column: "CommentWorkItemID");

            migrationBuilder.CreateIndex(
                name: "IX_WorkItemComment_TicketID",
                table: "WorkItemComment",
                column: "TicketID");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkItems_WorkItemPriorities_WorkItemPriorityID",
                table: "WorkItems",
                column: "WorkItemPriorityID",
                principalTable: "WorkItemPriorities",
                principalColumn: "PriorityID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkItems_WorkItemPriorities_WorkItemPriorityID",
                table: "WorkItems");

            migrationBuilder.DropTable(
                name: "WorkItemComment");

            migrationBuilder.DropIndex(
                name: "IX_WorkItems_WorkItemPriorityID",
                table: "WorkItems");

            migrationBuilder.DropColumn(
                name: "WorkItemPriorityID",
                table: "WorkItems");

            migrationBuilder.CreateTable(
                name: "TaskComments",
                columns: table => new
                {
                    CommentID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Created = table.Column<DateTime>(type: "Date", nullable: false),
                    Details = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    SubmittedBy = table.Column<string>(nullable: true),
                    TicketID = table.Column<string>(nullable: true),
                    Updated = table.Column<DateTime>(type: "Date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskComments", x => x.CommentID);
                    table.ForeignKey(
                        name: "FK_TaskComments_Tickets_TicketID",
                        column: x => x.TicketID,
                        principalTable: "Tickets",
                        principalColumn: "TicketID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TaskComments_TicketID",
                table: "TaskComments",
                column: "TicketID");
        }
    }
}
