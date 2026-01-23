using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace InternshipTrackerAPI.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Username = table.Column<string>(type: "TEXT", maxLength: 30, nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Internships",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CompanyName = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    RoleTitle = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Status = table.Column<int>(type: "INTEGER", nullable: false),
                    JobUrl = table.Column<string>(type: "TEXT", nullable: true),
                    DateApplied = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Internships", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Internships_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Notes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    Content = table.Column<string>(type: "TEXT", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    InternshipId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notes_Internships_InternshipId",
                        column: x => x.InternshipId,
                        principalTable: "Internships",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "Email", "PasswordHash", "Username" },
                values: new object[] { 1, new DateTime(2025, 11, 23, 7, 48, 5, 48, DateTimeKind.Utc).AddTicks(1060), "student@uni.edu", "student@123", "student1" });

            migrationBuilder.InsertData(
                table: "Internships",
                columns: new[] { "Id", "CompanyName", "DateApplied", "IsActive", "JobUrl", "RoleTitle", "Status", "UserId" },
                values: new object[,]
                {
                    { 1, "Safaricom", new DateTime(2026, 1, 18, 7, 48, 5, 48, DateTimeKind.Utc).AddTicks(1231), true, "https://safaricom.com/careers", "Software Engineering Intern", 1, 1 },
                    { 2, "Microsoft ADC", new DateTime(2025, 12, 23, 7, 48, 5, 48, DateTimeKind.Utc).AddTicks(1242), false, "https://careers.microsoft.com", "Program Manager Intern", 2, 1 },
                    { 3, "Cellulant", new DateTime(2026, 1, 23, 7, 48, 5, 48, DateTimeKind.Utc).AddTicks(1243), true, "https://cellulant.io/jobs", "Backend Developer", 0, 1 }
                });

            migrationBuilder.InsertData(
                table: "Notes",
                columns: new[] { "Id", "Content", "DateCreated", "InternshipId", "Title" },
                values: new object[,]
                {
                    { 1, "Spoke with Sarah. Asked about C# experience.", new DateTime(2026, 1, 19, 7, 48, 5, 48, DateTimeKind.Utc).AddTicks(1269), 1, "HR Screening" },
                    { 2, "Received link for coding assessment.", new DateTime(2026, 1, 22, 7, 48, 5, 48, DateTimeKind.Utc).AddTicks(1271), 1, "Technical Interview Invite" },
                    { 3, "Standard automated reply.", new DateTime(2025, 12, 25, 7, 48, 5, 48, DateTimeKind.Utc).AddTicks(1272), 2, "Rejection Email" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Internships_UserId",
                table: "Internships",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Notes_InternshipId",
                table: "Notes",
                column: "InternshipId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Username",
                table: "Users",
                column: "Username",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Notes");

            migrationBuilder.DropTable(
                name: "Internships");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
