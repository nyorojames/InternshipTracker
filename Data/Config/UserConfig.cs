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
                     PhoneNumber = "+254700000000",
                     PasswordHash = "$2a$11$uIvxJyfCWMRnPipkDTuC8Oh26zgd8y/khAhLcu7dHtQJq8F4l3waa",
                     CreatedAt = DateTime.UtcNow.AddMonths(-2)
                 }
             );
        }
    }
}
