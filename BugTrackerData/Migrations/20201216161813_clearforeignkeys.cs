using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BugTrackerData.Migrations
{
    public partial class clearforeignkeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkItemComments_WorkItems_CommentWorkItemID",
                table: "WorkItemComments");

            migrationBuilder.DropTable(
                name: "ProjectTaskStatusLogs");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "Date", nullable: false),
                    Description = table.Column<string>(nullable: true),
                    ProjectName = table.Column<string>(nullable: true)
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
                    ActualEndDate = table.Column<DateTime>(type: "Date", nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "Date", nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "Date", nullable: true),
                    StartDate = table.Column<DateTime>(type: "Date", nullable: true),
                    TargetEndDate = table.Column<DateTime>(type: "Date", nullable: true),
                    WorkItemDescription = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    WorkItemName = table.Column<string>(type: "nvarchar(120)", nullable: false),
                    WorkItemOwnerID = table.Column<string>(nullable: true),
                    WorkItemPriorityID = table.Column<int>(nullable: false),
                    WorkItemProjectID = table.Column<string>(nullable: true),
                    WorkItemStatusID = table.Column<int>(nullable: false),
                    WorkItemTypeID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkItems", x => x.WorkItemID);
                    table.ForeignKey(
                        name: "FK_WorkItems_ApplicationUserRoles_WorkItemOwnerID",
                        column: x => x.WorkItemOwnerID,
                        principalTable: "ApplicationUserRoles",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WorkItems_WorkItemPriorities_WorkItemPriorityID",
                        column: x => x.WorkItemPriorityID,
                        principalTable: "WorkItemPriorities",
                        principalColumn: "PriorityID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkItems_Projects_WorkItemProjectID",
                        column: x => x.WorkItemProjectID,
                        principalTable: "Projects",
                        principalColumn: "ProjectID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WorkItems_WorkItemStatuses_WorkItemStatusID",
                        column: x => x.WorkItemStatusID,
                        principalTable: "WorkItemStatuses",
                        principalColumn: "StatusID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkItems_WorkItemTypes_WorkItemTypeID",
                        column: x => x.WorkItemTypeID,
                        principalTable: "WorkItemTypes",
                        principalColumn: "TypeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    TicketID = table.Column<string>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "Date", nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "Date", nullable: true),
                    TicketDescription = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    TicketName = table.Column<string>(type: "nvarchar(120)", nullable: false),
                    TicketOwnerID = table.Column<string>(nullable: true),
                    TicketStatusID = table.Column<int>(nullable: false),
                    TicketTypeID = table.Column<int>(nullable: false),
                    TicketWorkItemID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.TicketID);
                    table.ForeignKey(
                        name: "FK_Tickets_ApplicationUserRoles_TicketOwnerID",
                        column: x => x.TicketOwnerID,
                        principalTable: "ApplicationUserRoles",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tickets_TicketStatuses_TicketStatusID",
                        column: x => x.TicketStatusID,
                        principalTable: "TicketStatuses",
                        principalColumn: "StatusID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tickets_TicketTypes_TicketTypeID",
                        column: x => x.TicketTypeID,
                        principalTable: "TicketTypes",
                        principalColumn: "TypeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tickets_WorkItems_TicketWorkItemID",
                        column: x => x.TicketWorkItemID,
                        principalTable: "WorkItems",
                        principalColumn: "WorkItemID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProjectTaskStatusLogs",
                columns: table => new
                {
                    ProjectTaskStatusId = table.Column<string>(nullable: false),
                    LogDate = table.Column<DateTime>(nullable: false),
                    StatusID = table.Column<int>(nullable: true),
                    TicketID = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectTaskStatusLogs", x => x.ProjectTaskStatusId);
                    table.ForeignKey(
                        name: "FK_ProjectTaskStatusLogs_TicketStatuses_StatusID",
                        column: x => x.StatusID,
                        principalTable: "TicketStatuses",
                        principalColumn: "StatusID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProjectTaskStatusLogs_Tickets_TicketID",
                        column: x => x.TicketID,
                        principalTable: "Tickets",
                        principalColumn: "TicketID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProjectTaskStatusLogs_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WorkItemComments_CommentWorkItemID",
                table: "WorkItemComments",
                column: "CommentWorkItemID");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectTaskStatusLogs_StatusID",
                table: "ProjectTaskStatusLogs",
                column: "StatusID");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectTaskStatusLogs_TicketID",
                table: "ProjectTaskStatusLogs",
                column: "TicketID");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectTaskStatusLogs_UserId",
                table: "ProjectTaskStatusLogs",
                column: "UserId");

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
                onDelete: ReferentialAction.Restrict);
        }
    }
}
