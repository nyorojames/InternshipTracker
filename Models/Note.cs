using System.ComponentModel.DataAnnotations;

namespace InternshipTrackerAPI.Models
{
    public class Note
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Title { get; set; } = string.Empty;

        [Required]
        public string Content { get; set; } = string.Empty;

        public DateTime DateCreated { get; set; } = DateTime.UtcNow;

        // Foreign Key
        public int InternshipId { get; set; }
        public Internship? Internship { get; set; } 
    }
}

