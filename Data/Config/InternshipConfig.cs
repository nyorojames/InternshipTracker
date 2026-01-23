using InternshipTrackerAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InternshipTrackerAPI.Data.Config
{
    public class InternshipConfig : IEntityTypeConfiguration<Internship>
    {
        public void Configure(EntityTypeBuilder<Internship> builder)
        {
            builder.ToTable("Internships");
            builder.HasKey(i => i.Id);

            builder.HasOne(i => i.User)
                      .WithMany() 
                      .HasForeignKey(i => i.UserId)
                      .OnDelete(DeleteBehavior.Cascade); // Deleting User deletes their Internships


            builder.HasData(
                new Internship
                {
                    Id = 1,
                    UserId = SeedConstants.DemoUserId,
                    CompanyName = "Safaricom",
                    RoleTitle = "Software Engineering Intern",
                    Status = InternshipStatus.Interviewing,
                    DateApplied = DateTime.UtcNow.AddDays(-5),
                    IsActive = true,
                    JobUrl = "https://safaricom.com/careers"
                },
                new Internship
                {
                    Id = 2,
                    UserId = SeedConstants.DemoUserId,
                    CompanyName = "Microsoft ADC",
                    RoleTitle = "Program Manager Intern",
                    Status = InternshipStatus.Rejected,
                    DateApplied = DateTime.UtcNow.AddMonths(-1),
                    IsActive = false,
                    JobUrl = "https://careers.microsoft.com"
                },
                new Internship
                {
                    Id = 3,
                    UserId = SeedConstants.DemoUserId,
                    CompanyName = "Cellulant",
                    RoleTitle = "Backend Developer",
                    Status = InternshipStatus.Applied,
                    DateApplied = DateTime.UtcNow,
                    IsActive = true,
                    JobUrl = "https://cellulant.io/jobs"
                });
        }
    }
}
