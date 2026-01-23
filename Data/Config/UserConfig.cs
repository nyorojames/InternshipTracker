using InternshipTrackerAPI.Models;
using InternshipTrackerAPI.Data; 
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InternshipTrackerAPI.Data.Config
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
            builder.HasKey(u => u.Id);

            builder.HasIndex(u => u.Username).IsUnique();
            builder.HasIndex(u => u.Email).IsUnique();

            builder.HasData(
                 new User
                 {
                     Id = SeedConstants.DemoUserId,
                     Username = "student1",
                     Email = "student@uni.edu",
                     PasswordHash = "student@123",
                     CreatedAt = DateTime.UtcNow.AddMonths(-2)
                 }
             );
        }
    }
}
