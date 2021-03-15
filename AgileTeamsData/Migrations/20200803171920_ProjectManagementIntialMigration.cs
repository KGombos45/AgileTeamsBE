using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AgileTeamsData.Migrations
{
    public partial class ProjectManagementIntialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApplicationUserRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: true),
                    RoleName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUserRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProjectStatuses",
                columns: table => new
                {
                    ProjectStatusId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProjectStatusName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectStatuses", x => x.ProjectStatusId);
                });

            migrationBuilder.CreateTable(
                name: "ProjectTaskStatuses",
                columns: table => new
                {
                    ProjectStatusId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProjectStatusName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectTaskStatuses", x => x.ProjectStatusId);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    ProjectId = table.Column<string>(nullable: false),
                    ProjectName = table.Column<string>(type: "nvarchar(120)", nullable: false),
                    ProjectDescription = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    ProjectStatusId = table.Column<int>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: false),
                    TargetEndDate = table.Column<DateTime>(nullable: false),
                    ActualEndDate = table.Column<DateTime>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    ModifiedOn = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.ProjectId);
                    table.ForeignKey(
                        name: "FK_Projects_ProjectStatuses_ProjectStatusId",
                        column: x => x.ProjectStatusId,
                        principalTable: "ProjectStatuses",
                        principalColumn: "ProjectStatusId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProjectTasks",
                columns: table => new
                {
                    TicketID = table.Column<string>(nullable: false),
                    TicketTitle = table.Column<string>(type: "nvarchar(120)", nullable: false),
                    TicketDescription = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    AssignedTo = table.Column<string>(nullable: true),
                    Submitter = table.Column<string>(nullable: true),
                    TicketPriority = table.Column<string>(nullable: true),
                    TicketType = table.Column<string>(nullable: true),
                    TicketStatus = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedOn = table.Column<DateTime>(nullable: false),
                    ClosedOn = table.Column<DateTime>(nullable: false),
                    ProjectId = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true),
                    StatusProjectStatusId = table.Column<int>(nullable: true)
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

            migrationBuilder.CreateTable(
                name: "ProjectTaskStatusLogs",
                columns: table => new
                {
                    ProjectTaskStatusId = table.Column<string>(nullable: false),
                    ProjectTaskTicketID = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true),
                    StatusProjectStatusId = table.Column<int>(nullable: true),
                    LogDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectTaskStatusLogs", x => x.ProjectTaskStatusId);
                    table.ForeignKey(
                        name: "FK_ProjectTaskStatusLogs_ProjectTasks_ProjectTaskTicketID",
                        column: x => x.ProjectTaskTicketID,
                        principalTable: "ProjectTasks",
                        principalColumn: "TicketID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProjectTaskStatusLogs_ProjectTaskStatuses_StatusProjectStatusId",
                        column: x => x.StatusProjectStatusId,
                        principalTable: "ProjectTaskStatuses",
                        principalColumn: "ProjectStatusId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProjectTaskStatusLogs_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TaskComments",
                columns: table => new
                {
                    CommentID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SubmittedBy = table.Column<string>(nullable: true),
                    Details = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    Updated = table.Column<DateTime>(nullable: false),
                    ProjectTaskTicketID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskComments", x => x.CommentID);
                    table.ForeignKey(
                        name: "FK_TaskComments_ProjectTasks_ProjectTaskTicketID",
                        column: x => x.ProjectTaskTicketID,
                        principalTable: "ProjectTasks",
                        principalColumn: "TicketID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Projects_ProjectStatusId",
                table: "Projects",
                column: "ProjectStatusId");

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

            migrationBuilder.CreateIndex(
                name: "IX_ProjectTaskStatusLogs_ProjectTaskTicketID",
                table: "ProjectTaskStatusLogs",
                column: "ProjectTaskTicketID");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectTaskStatusLogs_StatusProjectStatusId",
                table: "ProjectTaskStatusLogs",
                column: "StatusProjectStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectTaskStatusLogs_UserId",
                table: "ProjectTaskStatusLogs",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskComments_ProjectTaskTicketID",
                table: "TaskComments",
                column: "ProjectTaskTicketID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicationUserRoles");

            migrationBuilder.DropTable(
                name: "ProjectTaskStatusLogs");

            migrationBuilder.DropTable(
                name: "TaskComments");

            migrationBuilder.DropTable(
                name: "ProjectTasks");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "ProjectTaskStatuses");

            migrationBuilder.DropTable(
                name: "ProjectStatuses");
        }
    }
}
