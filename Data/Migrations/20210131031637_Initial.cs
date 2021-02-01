using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CourseDates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AvailiabilityDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseDates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourseDates_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CourseApplications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyPhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    CourseDateId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseApplications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourseApplications_CourseDates_CourseDateId",
                        column: x => x.CourseDateId,
                        principalTable: "CourseDates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CourseApplications_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CourseApplicationParticipants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CourseApplicationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseApplicationParticipants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourseApplicationParticipants_CourseApplications_CourseApplicationId",
                        column: x => x.CourseApplicationId,
                        principalTable: "CourseApplications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Cutting trees, the ins and outs" },
                    { 2, "CSS and you - a love story" },
                    { 3, "Baking mud cakes using actual mud" },
                    { 4, "Christmas eve - myth or reality?" },
                    { 5, "LEGO colors through time" }
                });

            migrationBuilder.InsertData(
                table: "CourseDates",
                columns: new[] { "Id", "AvailiabilityDate", "CourseId" },
                values: new object[,]
                {
                    { 1, new DateTime(2017, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 2, new DateTime(2017, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 3, new DateTime(2017, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 4, new DateTime(2017, 5, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 5, new DateTime(2017, 5, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 6, new DateTime(2017, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 7, new DateTime(2018, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 8, new DateTime(2017, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 9, new DateTime(2017, 12, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 11, new DateTime(2018, 12, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 12, new DateTime(2019, 12, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 13, new DateTime(2017, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourseApplicationParticipants_CourseApplicationId",
                table: "CourseApplicationParticipants",
                column: "CourseApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseApplications_CourseDateId",
                table: "CourseApplications",
                column: "CourseDateId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseApplications_CourseId",
                table: "CourseApplications",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseDates_CourseId",
                table: "CourseDates",
                column: "CourseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseApplicationParticipants");

            migrationBuilder.DropTable(
                name: "CourseApplications");

            migrationBuilder.DropTable(
                name: "CourseDates");

            migrationBuilder.DropTable(
                name: "Courses");
        }
    }
}
