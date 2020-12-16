using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BugTrackerData.Migrations
{
    public partial class clearforeignkeys1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CommentWorkItemID",
                table: "WorkItemComments",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    ProjectID = table.Column<string>(nullable: false),
                    ProjectName = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "Date", nullable: false),
                    CreatedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.ProjectID);
                });

            migrationBuilder.CreateTable(
                name: "WorkItems",
                columns: table => new
                {
                    WorkItemID = table.Column<string>(nullable: false),
                    WorkItemName = table.Column<string>(type: "nvarchar(120)", nullable: false),
                    WorkItemDescription = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    WorkItemProjectID = table.Column<string>(nullable: false),
                    WorkItemStatusID = table.Column<int>(nullable: true),
                    WorkItemTypeID = table.Column<int>(nullable: true),
                    WorkItemPriorityID = table.Column<int>(nullable: true),
                    WorkItemOwnerID = table.Column<string>(nullable: true),
                    StartDate = table.Column<DateTime>(type: "Date", nullable: true),
                    TargetEndDate = table.Column<DateTime>(type: "Date", nullable: true),
                    ActualEndDate = table.Column<DateTime>(type: "Date", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "Date", nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "Date", nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkItems", x => x.WorkItemID);
                    table.ForeignKey(
                        name: "FK_WorkItems_ApplicationUserRoles_WorkItemOwnerID",
                        column: x => x.WorkItemOwnerID,
                        principalTable: "ApplicationUserRoles",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_WorkItems_WorkItemPriorities_WorkItemPriorityID",
                        column: x => x.WorkItemPriorityID,
                        principalTable: "WorkItemPriorities",
                        principalColumn: "PriorityID",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_WorkItems_Projects_WorkItemProjectID",
                        column: x => x.WorkItemProjectID,
                        principalTable: "Projects",
                        principalColumn: "ProjectID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkItems_WorkItemStatuses_WorkItemStatusID",
                        column: x => x.WorkItemStatusID,
                        principalTable: "WorkItemStatuses",
                        principalColumn: "StatusID",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_WorkItems_WorkItemTypes_WorkItemTypeID",
                        column: x => x.WorkItemTypeID,
                        principalTable: "WorkItemTypes",
                        principalColumn: "TypeID",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    TicketID = table.Column<string>(nullable: false),
                    TicketName = table.Column<string>(type: "nvarchar(120)", nullable: false),
                    TicketDescription = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    TicketStatusID = table.Column<int>(nullable: true),
                    TicketTypeID = table.Column<int>(nullable: true),
                    TicketOwnerID = table.Column<string>(nullable: true),
                    TicketWorkItemID = table.Column<string>(nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "Date", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "Date", nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.TicketID);
                    table.ForeignKey(
                        name: "FK_Tickets_ApplicationUserRoles_TicketOwnerID",
                        column: x => x.TicketOwnerID,
                        principalTable: "ApplicationUserRoles",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Tickets_TicketStatuses_TicketStatusID",
                        column: x => x.TicketStatusID,
                        principalTable: "TicketStatuses",
                        principalColumn: "StatusID",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Tickets_TicketTypes_TicketTypeID",
                        column: x => x.TicketTypeID,
                        principalTable: "TicketTypes",
                        principalColumn: "TypeID",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Tickets_WorkItems_TicketWorkItemID",
                        column: x => x.TicketWorkItemID,
                        principalTable: "WorkItems",
                        principalColumn: "WorkItemID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WorkItemComments_CommentWorkItemID",
                table: "WorkItemComments",
                column: "CommentWorkItemID");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_TicketOwnerID",
                table: "Tickets",
                column: "TicketOwnerID");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_TicketStatusID",
                table: "Tickets",
                column: "TicketStatusID");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_TicketTypeID",
                table: "Tickets",
                column: "TicketTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_TicketWorkItemID",
                table: "Tickets",
                column: "TicketWorkItemID");

            migrationBuilder.CreateIndex(
                name: "IX_WorkItems_WorkItemOwnerID",
                table: "WorkItems",
                column: "WorkItemOwnerID");

            migrationBuilder.CreateIndex(
                name: "IX_WorkItems_WorkItemPriorityID",
                table: "WorkItems",
                column: "WorkItemPriorityID");

            migrationBuilder.CreateIndex(
                name: "IX_WorkItems_WorkItemProjectID",
                table: "WorkItems",
                column: "WorkItemProjectID");

            migrationBuilder.CreateIndex(
                name: "IX_WorkItems_WorkItemStatusID",
                table: "WorkItems",
                column: "WorkItemStatusID");

            migrationBuilder.CreateIndex(
                name: "IX_WorkItems_WorkItemTypeID",
                table: "WorkItems",
                column: "WorkItemTypeID");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkItemComments_WorkItems_CommentWorkItemID",
                table: "WorkItemComments",
                column: "CommentWorkItemID",
                principalTable: "WorkItems",
                principalColumn: "WorkItemID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkItemComments_WorkItems_CommentWorkItemID",
                table: "WorkItemComments");

            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "WorkItems");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropIndex(
                name: "IX_WorkItemComments_CommentWorkItemID",
                table: "WorkItemComments");

            migrationBuilder.AlterColumn<string>(
                name: "CommentWorkItemID",
                table: "WorkItemComments",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
