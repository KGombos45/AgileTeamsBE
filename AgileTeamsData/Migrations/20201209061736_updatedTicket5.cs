using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AgileTeamsData.Migrations
{
    public partial class updatedTicket5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectTaskStatusLogs_ProjectTaskStatuses_StatusProjectStatusId",
                table: "ProjectTaskStatusLogs");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_AspNetUsers_TicketOwnerId",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Projects_TicketProjectProjectId",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_ProjectStatuses_TicketStatusProjectStatusId",
                table: "Tickets");

            migrationBuilder.DropTable(
                name: "ProjectTaskStatuses");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_TicketStatusProjectStatusId",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "TicketStatusProjectStatusId",
                table: "Tickets");

            migrationBuilder.RenameColumn(
                name: "TicketOwnerId",
                table: "Tickets",
                newName: "TicketOwnerID");

            migrationBuilder.RenameColumn(
                name: "TicketProjectProjectId",
                table: "Tickets",
                newName: "TicketProjectID");

            migrationBuilder.RenameIndex(
                name: "IX_Tickets_TicketOwnerId",
                table: "Tickets",
                newName: "IX_Tickets_TicketOwnerID");

            migrationBuilder.RenameIndex(
                name: "IX_Tickets_TicketProjectProjectId",
                table: "Tickets",
                newName: "IX_Tickets_TicketProjectID");

            migrationBuilder.RenameColumn(
                name: "StatusProjectStatusId",
                table: "ProjectTaskStatusLogs",
                newName: "StatusID");

            migrationBuilder.RenameIndex(
                name: "IX_ProjectTaskStatusLogs_StatusProjectStatusId",
                table: "ProjectTaskStatusLogs",
                newName: "IX_ProjectTaskStatusLogs_StatusID");

            migrationBuilder.AddColumn<int>(
                name: "TicketStatusID",
                table: "Tickets",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "TicketStatuses",
                columns: table => new
                {
                    StatusID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StatusName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketStatuses", x => x.StatusID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_TicketStatusID",
                table: "Tickets",
                column: "TicketStatusID");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectTaskStatusLogs_TicketStatuses_StatusID",
                table: "ProjectTaskStatusLogs",
                column: "StatusID",
                principalTable: "TicketStatuses",
                principalColumn: "StatusID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_AspNetUsers_TicketOwnerID",
                table: "Tickets",
                column: "TicketOwnerID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Projects_TicketProjectID",
                table: "Tickets",
                column: "TicketProjectID",
                principalTable: "Projects",
                principalColumn: "ProjectId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_TicketStatuses_TicketStatusID",
                table: "Tickets",
                column: "TicketStatusID",
                principalTable: "TicketStatuses",
                principalColumn: "StatusID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectTaskStatusLogs_TicketStatuses_StatusID",
                table: "ProjectTaskStatusLogs");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_AspNetUsers_TicketOwnerID",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Projects_TicketProjectID",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_TicketStatuses_TicketStatusID",
                table: "Tickets");

            migrationBuilder.DropTable(
                name: "TicketStatuses");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_TicketStatusID",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "TicketStatusID",
                table: "Tickets");

            migrationBuilder.RenameColumn(
                name: "TicketOwnerID",
                table: "Tickets",
                newName: "TicketOwnerId");

            migrationBuilder.RenameColumn(
                name: "TicketProjectID",
                table: "Tickets",
                newName: "TicketProjectProjectId");

            migrationBuilder.RenameIndex(
                name: "IX_Tickets_TicketOwnerID",
                table: "Tickets",
                newName: "IX_Tickets_TicketOwnerId");

            migrationBuilder.RenameIndex(
                name: "IX_Tickets_TicketProjectID",
                table: "Tickets",
                newName: "IX_Tickets_TicketProjectProjectId");

            migrationBuilder.RenameColumn(
                name: "StatusID",
                table: "ProjectTaskStatusLogs",
                newName: "StatusProjectStatusId");

            migrationBuilder.RenameIndex(
                name: "IX_ProjectTaskStatusLogs_StatusID",
                table: "ProjectTaskStatusLogs",
                newName: "IX_ProjectTaskStatusLogs_StatusProjectStatusId");

            migrationBuilder.AddColumn<int>(
                name: "TicketStatusProjectStatusId",
                table: "Tickets",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_TicketStatusProjectStatusId",
                table: "Tickets",
                column: "TicketStatusProjectStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectTaskStatusLogs_ProjectTaskStatuses_StatusProjectStatusId",
                table: "ProjectTaskStatusLogs",
                column: "StatusProjectStatusId",
                principalTable: "ProjectTaskStatuses",
                principalColumn: "ProjectStatusId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_AspNetUsers_TicketOwnerId",
                table: "Tickets",
                column: "TicketOwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Projects_TicketProjectProjectId",
                table: "Tickets",
                column: "TicketProjectProjectId",
                principalTable: "Projects",
                principalColumn: "ProjectId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_ProjectStatuses_TicketStatusProjectStatusId",
                table: "Tickets",
                column: "TicketStatusProjectStatusId",
                principalTable: "ProjectStatuses",
                principalColumn: "ProjectStatusId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
