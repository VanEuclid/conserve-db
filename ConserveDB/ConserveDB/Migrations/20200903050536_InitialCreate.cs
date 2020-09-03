using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ConserveDB.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    departmentName = table.Column<string>(nullable: false),
                    position = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Members",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: false),
                    Address = table.Column<string>(nullable: true),
                    EmailAddress = table.Column<string>(nullable: false),
                    PreferredContactPhoneNumber = table.Column<string>(nullable: false),
                    Position = table.Column<string>(nullable: false),
                    Department = table.Column<string>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    EmploymentStatus = table.Column<string>(nullable: false),
                    Shift = table.Column<string>(nullable: false),
                    Manager = table.Column<string>(nullable: false),
                    TeamMemberPhoto = table.Column<string>(nullable: true),
                    FavoriteColor = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "Members");
        }
    }
}
