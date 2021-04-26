using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Enkaizen.Todo.Web.Data.Migrations
{
    public partial class TodoData_InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Todos",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(maxLength: 100, nullable: false),
                    IsDone = table.Column<bool>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: false),
                    ModifierId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Todos", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Todos");
        }
    }
}
