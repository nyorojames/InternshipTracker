using System.ComponentModel.DataAnnotations;

namespace InternshipTrackerAPI.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string Username { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Phone]
        public string PhoneNumber { get; set; } = string.Empty;

        [Required]
        public string PasswordHash { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}

