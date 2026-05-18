using InternshipTrackerAPI.Data.Config;
using InternshipTrackerAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace InternshipTrackerAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Internship> Internships { get; set; }
        public DbSet<Note> Notes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Table 1
            modelBuilder.ApplyConfiguration(new UserConfig());

            // Table 2
            modelBuilder.ApplyConfiguration(new InternshipConfig());

            // Table 3
            modelBuilder.ApplyConfiguration(new NoteConfig());
        }
    }
}