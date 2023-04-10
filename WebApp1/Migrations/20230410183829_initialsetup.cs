using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApp1.Migrations
{
    public partial class initialsetup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Shout",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShoutEntry = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShoutDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ShoutName = table.Column<string>(type: "nvarchar(max)", nullable:false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shout", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Shout");
        }
    }
}
