using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AgileTeamsData.Migrations
{
    public partial class updatedModels15 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WorkItemComments",
                columns: table => new
                {
                    CommentID = table.Column<string>(nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    SubmittedBy = table.Column<string>(nullable: false),
                    SubmittedOn = table.Column<DateTime>(type: "Date", nullable: false),
                    CommentWorkItemID = table.Column<string>(nullable: false)
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
                });

            migrationBuilder.CreateIndex(
                name: "IX_WorkItemComments_CommentWorkItemID",
                table: "WorkItemComments",
                column: "CommentWorkItemID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WorkItemComments");
        }
    }
}
