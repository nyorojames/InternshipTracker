using System.ComponentModel.DataAnnotations;

namespace InternshipTrackerAPI.DTOs
{
    public class CreateNoteDto
    {
        [Required]
        public int InternshipId { get; set; }

        [Required]
        public string Title { get; set; } = string.Empty;

        [Required]
        public string Content { get; set; } = string.Empty;
    }
}