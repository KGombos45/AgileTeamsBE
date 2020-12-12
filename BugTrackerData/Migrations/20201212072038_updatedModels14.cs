using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BugTrackerData.Migrations
{
    public partial class updatedModels14 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WorkItemComments");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WorkItemComments",
                columns: table => new
                {
                    CommentID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Comment = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    CommentWorkItemID = table.Column<string>(nullable: true),
                    SubmittedBy = table.Column<string>(nullable: true),
                    SubmittedOn = table.Column<DateTime>(type: "Date", nullable: false),
                    TicketID = table.Column<string>(nullable: true),
                    Updated = table.Column<DateTime>(type: "Date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkItemComments", x => x.CommentID);
                    table.ForeignKey(
                        name: "FK_WorkItemComments_WorkItems_CommentWorkItemID",
                        column: x => x.CommentWorkItemID,
                        principalTable: "WorkItems",
                        principalColumn: "WorkItemID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WorkItemComments_Tickets_TicketID",
                        column: x => x.TicketID,
                        principalTable: "Tickets",
                        principalColumn: "TicketID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WorkItemComments_CommentWorkItemID",
                table: "WorkItemComments",
                column: "CommentWorkItemID");

            migrationBuilder.CreateIndex(
                name: "IX_WorkItemComments_TicketID",
                table: "WorkItemComments",
                column: "TicketID");
        }
    }
}
