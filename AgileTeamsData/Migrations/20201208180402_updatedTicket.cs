using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AgileTeamsData.Migrations
{
    public partial class updatedTicket : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectTaskStatusLogs_ProjectTasks_ProjectTaskTicketID",
                table: "ProjectTaskStatusLogs");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskComments_ProjectTasks_ProjectTaskTicketID",
                table: "TaskComments");

            migrationBuilder.DropTable(
                name: "ProjectTasks");

            migrationBuilder.RenameColumn(
                name: "ProjectTaskTicketID",
                table: "TaskComments",
                newName: "TicketID");

            migrationBuilder.RenameIndex(
                name: "IX_TaskComments_ProjectTaskTicketID",
                table: "TaskComments",
                newName: "IX_TaskComments_TicketID");

            migrationBuilder.RenameColumn(
                name: "ProjectTaskTicketID",
                table: "ProjectTaskStatusLogs",
                newName: "TicketID");

            migrationBuilder.RenameIndex(
                name: "IX_ProjectTaskStatusLogs_ProjectTaskTicketID",
                table: "ProjectTaskStatusLogs",
                newName: "IX_ProjectTaskStatusLogs_TicketID");

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    TicketID = table.Column<string>(nullable: false),
                    TicketName = table.Column<string>(type: "nvarchar(120)", nullable: false),
                    TicketDescription = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    TicketOwner = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "Date", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "Date", nullable: true),
                    ProjectId = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true),
                    StatusProjectStatusId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.TicketID);
                    table.ForeignKey(
                        name: "FK_Tickets_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tickets_ProjectTaskStatuses_StatusProjectStatusId",
                        column: x => x.StatusProjectStatusId,
                        principalTable: "ProjectTaskStatuses",
                        principalColumn: "ProjectStatusId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tickets_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_ProjectId",
                table: "Tickets",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_StatusProjectStatusId",
                table: "Tickets",
                column: "StatusProjectStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_UserId",
                table: "Tickets",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectTaskStatusLogs_Tickets_TicketID",
                table: "ProjectTaskStatusLogs",
                column: "TicketID",
                principalTable: "Tickets",
                principalColumn: "TicketID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskComments_Tickets_TicketID",
                table: "TaskComments",
                column: "TicketID",
                principalTable: "Tickets",
                principalColumn: "TicketID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectTaskStatusLogs_Tickets_TicketID",
                table: "ProjectTaskStatusLogs");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskComments_Tickets_TicketID",
                table: "TaskComments");

            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.RenameColumn(
                name: "TicketID",
                table: "TaskComments",
                newName: "ProjectTaskTicketID");

            migrationBuilder.RenameIndex(
                name: "IX_TaskComments_TicketID",
                table: "TaskComments",
                newName: "IX_TaskComments_ProjectTaskTicketID");

            migrationBuilder.RenameColumn(
                name: "TicketID",
                table: "ProjectTaskStatusLogs",
                newName: "ProjectTaskTicketID");

            migrationBuilder.RenameIndex(
                name: "IX_ProjectTaskStatusLogs_TicketID",
                table: "ProjectTaskStatusLogs",
                newName: "IX_ProjectTaskStatusLogs_ProjectTaskTicketID");

            migrationBuilder.CreateTable(
                name: "ProjectTasks",
                columns: table => new
                {
                    TicketID = table.Column<string>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "Date", nullable: false),
                    ProjectId = table.Column<string>(nullable: true),
                    StatusProjectStatusId = table.Column<int>(nullable: true),
                    TicketDescription = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    TicketName = table.Column<string>(type: "nvarchar(120)", nullable: false),
                    TicketOwner = table.Column<string>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "Date", nullable: true),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectTasks", x => x.TicketID);
                    table.ForeignKey(
                        name: "FK_ProjectTasks_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProjectTasks_ProjectTaskStatuses_StatusProjectStatusId",
                        column: x => x.StatusProjectStatusId,
                        principalTable: "ProjectTaskStatuses",
                        principalColumn: "ProjectStatusId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProjectTasks_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProjectTasks_ProjectId",
                table: "ProjectTasks",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectTasks_StatusProjectStatusId",
                table: "ProjectTasks",
                column: "StatusProjectStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectTasks_UserId",
                table: "ProjectTasks",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectTaskStatusLogs_ProjectTasks_ProjectTaskTicketID",
                table: "ProjectTaskStatusLogs",
                column: "ProjectTaskTicketID",
                principalTable: "ProjectTasks",
                principalColumn: "TicketID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskComments_ProjectTasks_ProjectTaskTicketID",
                table: "TaskComments",
                column: "ProjectTaskTicketID",
                principalTable: "ProjectTasks",
                principalColumn: "TicketID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
