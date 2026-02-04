using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InternshipTrackerAPI.Migrations
{
    /// <inheritdoc />
    public partial class PhoneNumberCreated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Users",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

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
                columns: new[] { "CreatedAt", "PhoneNumber" },
                values: new object[] { new DateTime(2025, 12, 4, 6, 38, 43, 602, DateTimeKind.Utc).AddTicks(4890), "" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Users");

            migrationBuilder.UpdateData(
                table: "Internships",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateApplied",
                value: new DateTime(2026, 1, 18, 7, 48, 5, 48, DateTimeKind.Utc).AddTicks(1231));

            migrationBuilder.UpdateData(
                table: "Internships",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateApplied",
                value: new DateTime(2025, 12, 23, 7, 48, 5, 48, DateTimeKind.Utc).AddTicks(1242));

            migrationBuilder.UpdateData(
                table: "Internships",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateApplied",
                value: new DateTime(2026, 1, 23, 7, 48, 5, 48, DateTimeKind.Utc).AddTicks(1243));

            migrationBuilder.UpdateData(
                table: "Notes",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2026, 1, 19, 7, 48, 5, 48, DateTimeKind.Utc).AddTicks(1269));

            migrationBuilder.UpdateData(
                table: "Notes",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2026, 1, 22, 7, 48, 5, 48, DateTimeKind.Utc).AddTicks(1271));

            migrationBuilder.UpdateData(
                table: "Notes",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2025, 12, 25, 7, 48, 5, 48, DateTimeKind.Utc).AddTicks(1272));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 23, 7, 48, 5, 48, DateTimeKind.Utc).AddTicks(1060));
        }
    }
}
