using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BugTrackerData.Migrations
{
    public partial class updatedModels5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_AspNetUsers_ProjectOwnerID",
                table: "Projects");

            migrationBuilder.DropForeignKey(
                name: "FK_Projects_ProjectStatuses_ProjectStatusID",
                table: "Projects");

            migrationBuilder.DropForeignKey(
                name: "FK_Projects_ProjectTypes_ProjectTypeID",
                table: "Projects");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Projects_TicketProjectID",
                table: "Tickets");

            migrationBuilder.DropTable(
                name: "ProjectStatuses");

            migrationBuilder.DropTable(
                name: "ProjectTypes");

            migrationBuilder.DropIndex(
                name: "IX_Projects_ProjectOwnerID",
                table: "Projects");

            migrationBuilder.DropIndex(
                name: "IX_Projects_ProjectStatusID",
                table: "Projects");

            migrationBuilder.DropIndex(
                name: "IX_Projects_ProjectTypeID",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "ActualEndDate",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "ProjectDescription",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "ProjectOwnerID",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "ProjectStatusID",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "ProjectTypeID",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "TargetEndDate",
                table: "Projects");

            migrationBuilder.AddColumn<string>(
                name: "ProjectID",
                table: "Tickets",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ProjectName",
                table: "Projects",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(120)");

            migrationBuilder.CreateTable(
                name: "WorkItemStatuses",
                columns: table => new
                {
                    StatusID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StatusName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkItemStatuses", x => x.StatusID);
                });

            migrationBuilder.CreateTable(
                name: "WorkItemTypes",
                columns: table => new
                {
                    TypeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TypeName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkItemTypes", x => x.TypeID);
                });

            migrationBuilder.CreateTable(
                name: "WorkItems",
                columns: table => new
                {
                    WorkItemID = table.Column<string>(nullable: false),
                    WorkItemName = table.Column<string>(type: "nvarchar(120)", nullable: false),
                    WorkItemDescription = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    WorkItemProjectID = table.Column<string>(nullable: true),
                    WorkItemStatusID = table.Column<int>(nullable: false),
                    WorkItemTypeID = table.Column<int>(nullable: false),
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
                        name: "FK_WorkItems_AspNetUsers_WorkItemOwnerID",
                        column: x => x.WorkItemOwnerID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_ProjectID",
                table: "Tickets",
                column: "ProjectID");

            migrationBuilder.CreateIndex(
                name: "IX_WorkItems_WorkItemOwnerID",
                table: "WorkItems",
                column: "WorkItemOwnerID");

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
                name: "FK_Tickets_Projects_ProjectID",
                table: "Tickets",
                column: "ProjectID",
                principalTable: "Projects",
                principalColumn: "ProjectID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_WorkItems_TicketProjectID",
                table: "Tickets",
                column: "TicketProjectID",
                principalTable: "WorkItems",
                principalColumn: "WorkItemID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Projects_ProjectID",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_WorkItems_TicketProjectID",
                table: "Tickets");

            migrationBuilder.DropTable(
                name: "WorkItems");

            migrationBuilder.DropTable(
                name: "WorkItemStatuses");

            migrationBuilder.DropTable(
                name: "WorkItemTypes");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_ProjectID",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "ProjectID",
                table: "Tickets");

            migrationBuilder.AlterColumn<string>(
                name: "ProjectName",
                table: "Projects",
                type: "nvarchar(120)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ActualEndDate",
                table: "Projects",
                type: "Date",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Projects",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Projects",
                type: "Date",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "Projects",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "Projects",
                type: "Date",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProjectDescription",
                table: "Projects",
                type: "nvarchar(MAX)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProjectOwnerID",
                table: "Projects",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProjectStatusID",
                table: "Projects",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProjectTypeID",
                table: "Projects",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "Projects",
                type: "Date",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "TargetEndDate",
                table: "Projects",
                type: "Date",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ProjectStatuses",
                columns: table => new
                {
                    StatusID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StatusName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectStatuses", x => x.StatusID);
                });

            migrationBuilder.CreateTable(
                name: "ProjectTypes",
                columns: table => new
                {
                    TypeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TypeName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectTypes", x => x.TypeID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Projects_ProjectOwnerID",
                table: "Projects",
                column: "ProjectOwnerID");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_ProjectStatusID",
                table: "Projects",
                column: "ProjectStatusID");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_ProjectTypeID",
                table: "Projects",
                column: "ProjectTypeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_AspNetUsers_ProjectOwnerID",
                table: "Projects",
                column: "ProjectOwnerID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_ProjectStatuses_ProjectStatusID",
                table: "Projects",
                column: "ProjectStatusID",
                principalTable: "ProjectStatuses",
                principalColumn: "StatusID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_ProjectTypes_ProjectTypeID",
                table: "Projects",
                column: "ProjectTypeID",
                principalTable: "ProjectTypes",
                principalColumn: "TypeID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Projects_TicketProjectID",
                table: "Tickets",
                column: "TicketProjectID",
                principalTable: "Projects",
                principalColumn: "ProjectID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
