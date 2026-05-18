using InternshipTrackerAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InternshipTrackerAPI.Data.Config
{
    public class NoteConfig : IEntityTypeConfiguration<Note>
    {
        public void Configure(EntityTypeBuilder<Note> builder)
        {
            builder.ToTable("Notes");
            builder.HasKey(n => n.Id);

            builder.HasOne(n => n.Internship)
                      .WithMany()
                      .HasForeignKey(n => n.InternshipId)
                      .OnDelete(DeleteBehavior.Cascade);

            builder.HasData(
                new Note
                {
                    Id = 1,
                    InternshipId = 1,
                    Title = "HR Screening",
                    Content = "Spoke with Sarah. Asked about C# experience.",
                    DateCreated = DateTime.UtcNow.AddDays(-4)
                },
                new Note
                {
                    Id = 2,
                    InternshipId = 1,
                    Title = "Technical Interview Invite",
                    Content = "Received link for coding assessment.",
                    DateCreated = DateTime.UtcNow.AddDays(-1)
                },
                new Note
                {
                    Id = 3,
                    InternshipId = 2,
                    Title = "Rejection Email",
                    Content = "Standard automated reply.",
                    DateCreated = DateTime.UtcNow.AddMonths(-1).AddDays(2)
                });
        }
    }
}
