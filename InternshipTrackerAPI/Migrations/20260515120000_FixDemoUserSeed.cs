using InternshipTrackerAPI.Data;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InternshipTrackerAPI.Migrations
{
    /// <inheritdoc />
    [DbContext(typeof(AppDbContext))]
    [Migration("20260515120000_FixDemoUserSeed")]
    public partial class FixDemoUserSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("""
                UPDATE Users
                SET PasswordHash = '$2a$11$uIvxJyfCWMRnPipkDTuC8Oh26zgd8y/khAhLcu7dHtQJq8F4l3waa',
                    PhoneNumber = '+254700000000'
                WHERE Id = 1;
                """);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("""
                UPDATE Users
                SET PhoneNumber = ''
                WHERE Id = 1;
                """);
        }
    }
}
