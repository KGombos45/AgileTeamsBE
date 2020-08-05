using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BugTrackerData.Migrations
{
    public partial class AddTaskPriority : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_ProjectStatuses_ProjectStatusId",
                table: "Projects");

            migrationBuilder.DropIndex(
                name: "IX_Projects_ProjectStatusId",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "TicketPriority",
                table: "ProjectTasks");

            migrationBuilder.DropColumn(
                name: "TicketStatus",
                table: "ProjectTasks");

            migrationBuilder.DropColumn(
                name: "TicketType",
                table: "ProjectTasks");

            migrationBuilder.AddColumn<int>(
                name: "PriorityProjectPriorityId",
                table: "ProjectTasks",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProjectStatusId",
                table: "Projects",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "ProjectTaskPriorities",
                columns: table => new
                {
                    ProjectPriorityId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProjectPriorityName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectTaskPriorities", x => x.ProjectPriorityId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProjectTasks_PriorityProjectPriorityId",
                table: "ProjectTasks",
                column: "PriorityProjectPriorityId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectTasks_ProjectTaskPriorities_PriorityProjectPriorityId",
                table: "ProjectTasks",
                column: "PriorityProjectPriorityId",
                principalTable: "ProjectTaskPriorities",
                principalColumn: "ProjectPriorityId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectTasks_ProjectTaskPriorities_PriorityProjectPriorityId",
                table: "ProjectTasks");

            migrationBuilder.DropTable(
                name: "ProjectTaskPriorities");

            migrationBuilder.DropIndex(
                name: "IX_ProjectTasks_PriorityProjectPriorityId",
                table: "ProjectTasks");

            migrationBuilder.DropColumn(
                name: "PriorityProjectPriorityId",
                table: "ProjectTasks");

            migrationBuilder.AddColumn<string>(
                name: "TicketPriority",
                table: "ProjectTasks",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TicketStatus",
                table: "ProjectTasks",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TicketType",
                table: "ProjectTasks",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProjectStatusId",
                table: "Projects",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_Projects_ProjectStatusId",
                table: "Projects",
                column: "ProjectStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_ProjectStatuses_ProjectStatusId",
                table: "Projects",
                column: "ProjectStatusId",
                principalTable: "ProjectStatuses",
                principalColumn: "ProjectStatusId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
