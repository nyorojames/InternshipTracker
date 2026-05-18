using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InternshipTrackerAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddInternshipSourceAndDeadline : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Deadline",
                table: "Internships",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Source",
                table: "Internships",
                type: "TEXT",
                maxLength: 100,
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Internships",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateApplied", "Deadline", "Source" },
                values: new object[] { new DateTime(2026, 5, 10, 17, 55, 58, 272, DateTimeKind.Utc).AddTicks(3364), new DateTime(2026, 5, 23, 17, 55, 58, 272, DateTimeKind.Utc).AddTicks(3377), "LinkedIn" });

            migrationBuilder.UpdateData(
                table: "Internships",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateApplied", "Deadline", "Source" },
                values: new object[] { new DateTime(2026, 4, 15, 17, 55, 58, 272, DateTimeKind.Utc).AddTicks(3386), new DateTime(2026, 5, 13, 17, 55, 58, 272, DateTimeKind.Utc).AddTicks(3392), "University" });

            migrationBuilder.UpdateData(
                table: "Internships",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateApplied", "Deadline", "Source" },
                values: new object[] { new DateTime(2026, 5, 15, 17, 55, 58, 272, DateTimeKind.Utc).AddTicks(3396), new DateTime(2026, 5, 18, 17, 55, 58, 272, DateTimeKind.Utc).AddTicks(3398), "Cold email" });

            migrationBuilder.UpdateData(
                table: "Notes",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2026, 5, 11, 17, 55, 58, 272, DateTimeKind.Utc).AddTicks(9897));

            migrationBuilder.UpdateData(
                table: "Notes",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2026, 5, 14, 17, 55, 58, 272, DateTimeKind.Utc).AddTicks(9908));

            migrationBuilder.UpdateData(
                table: "Notes",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2026, 4, 17, 17, 55, 58, 272, DateTimeKind.Utc).AddTicks(9912));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 15, 17, 55, 58, 271, DateTimeKind.Utc).AddTicks(6207));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Deadline",
                table: "Internships");

            migrationBuilder.DropColumn(
                name: "Source",
                table: "Internships");

            migrationBuilder.UpdateData(
                table: "Internships",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateApplied",
                value: new DateTime(2026, 1, 30, 6, 38, 43, 602, DateTimeKind.Utc).AddTicks(6059));

            migrationBuilder.UpdateData(
                table: "Internships",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateApplied",
                value: new DateTime(2026, 1, 4, 6, 38, 43, 602, DateTimeKind.Utc).AddTicks(6067));

            migrationBuilder.UpdateData(
                table: "Internships",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateApplied",
                value: new DateTime(2026, 2, 4, 6, 38, 43, 602, DateTimeKind.Utc).AddTicks(6137));

            migrationBuilder.UpdateData(
                table: "Notes",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2026, 1, 31, 6, 38, 43, 602, DateTimeKind.Utc).AddTicks(6994));

            migrationBuilder.UpdateData(
                table: "Notes",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2026, 2, 3, 6, 38, 43, 602, DateTimeKind.Utc).AddTicks(6997));

            migrationBuilder.UpdateData(
                table: "Notes",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2026, 1, 6, 6, 38, 43, 602, DateTimeKind.Utc).AddTicks(7000));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 6, 38, 43, 602, DateTimeKind.Utc).AddTicks(4890));
        }
    }
}
