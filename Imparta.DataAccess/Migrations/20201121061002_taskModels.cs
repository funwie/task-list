using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Imparta.DataAccess.Migrations
{
    public partial class taskModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TaskList",
                columns: table => new
                {
                    TaskListId = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(type: "varchar(255)", nullable: false),
                    OwnerId = table.Column<string>(nullable: false),
                    CreatedDate = table.Column<DateTimeOffset>(nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskList", x => x.TaskListId);
                });

            migrationBuilder.CreateTable(
                name: "Task",
                columns: table => new
                {
                    TaskId = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(type: "varchar(1000)", nullable: false),
                    Status = table.Column<int>(nullable: false),
                    Start = table.Column<DateTimeOffset>(nullable: false),
                    End = table.Column<DateTimeOffset>(nullable: false),
                    CreatedDate = table.Column<DateTimeOffset>(nullable: false, defaultValueSql: "GETDATE()"),
                    TaskListId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Task", x => x.TaskId);
                    table.ForeignKey(
                        name: "FK_Task_TaskList_TaskListId",
                        column: x => x.TaskListId,
                        principalTable: "TaskList",
                        principalColumn: "TaskListId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Task_Description",
                table: "Task",
                column: "Description");

            migrationBuilder.CreateIndex(
                name: "IX_Task_TaskListId",
                table: "Task",
                column: "TaskListId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskList_Title",
                table: "TaskList",
                column: "Title");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Task");

            migrationBuilder.DropTable(
                name: "TaskList");
        }
    }
}
