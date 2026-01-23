using System.ComponentModel.DataAnnotations;

namespace InternshipTrackerAPI.Models
{
    public class Internship
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string CompanyName { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string RoleTitle { get; set; } = string.Empty;

        public InternshipStatus Status { get; set; } = InternshipStatus.Applied;

        public string? JobUrl { get; set; }

        public DateTime DateApplied { get; set; } = DateTime.UtcNow;

        public bool IsActive { get; set; } = true;

        // Foreign Key
        public int UserId { get; set; }
        public User? User { get; set; }
    }
    }
}