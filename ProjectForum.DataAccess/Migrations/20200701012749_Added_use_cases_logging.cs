using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectForum.EfDataAccess.Migrations
{
    public partial class Added_use_cases_logging : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UseCaseLogs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(nullable: false),
                    UseCaseName = table.Column<string>(nullable: true),
                    Data = table.Column<string>(type: "text", nullable: true),
                    Actor = table.Column<string>(nullable: true),
                    ActorRole = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UseCaseLogs", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UseCaseLogs");
        }
    }
}
