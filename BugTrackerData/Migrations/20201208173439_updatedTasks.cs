using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BugTrackerData.Migrations
{
    public partial class updatedTasks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectTasks_ProjectTaskPriorities_PriorityProjectPriorityId",
                table: "ProjectTasks");

            migrationBuilder.DropIndex(
                name: "IX_ProjectTasks_PriorityProjectPriorityId",
                table: "ProjectTasks");

            migrationBuilder.DropColumn(
                name: "ClosedOn",
                table: "ProjectTasks");

            migrationBuilder.DropColumn(
                name: "PriorityProjectPriorityId",
                table: "ProjectTasks");

            migrationBuilder.RenameColumn(
                name: "TicketTitle",
                table: "ProjectTasks",
                newName: "TicketName");

            migrationBuilder.RenameColumn(
                name: "Submitter",
                table: "ProjectTasks",
                newName: "TicketOwner");

            migrationBuilder.RenameColumn(
                name: "AssignedTo",
                table: "ProjectTasks",
                newName: "CreatedBy");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TicketOwner",
                table: "ProjectTasks",
                newName: "Submitter");

            migrationBuilder.RenameColumn(
                name: "TicketName",
                table: "ProjectTasks",
                newName: "TicketTitle");

            migrationBuilder.RenameColumn(
                name: "CreatedBy",
                table: "ProjectTasks",
                newName: "AssignedTo");

            migrationBuilder.AddColumn<DateTime>(
                name: "ClosedOn",
                table: "ProjectTasks",
                type: "Date",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PriorityProjectPriorityId",
                table: "ProjectTasks",
                nullable: true);

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
    }
}
