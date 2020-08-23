using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ConserveDB.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Member",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    EmailAddress = table.Column<string>(nullable: true),
                    PreferredContactPhoneNumber = table.Column<string>(nullable: true),
                    Position = table.Column<string>(nullable: true),
                    Department = table.Column<string>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    EmploymentStatus = table.Column<string>(nullable: true),
                    Shift = table.Column<string>(nullable: true),
                    Manager = table.Column<string>(nullable: true),
                    TeamMemberPhoto = table.Column<string>(nullable: true),
                    FavoriteColor = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Member", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Member");
        }
    }
}
