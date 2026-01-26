using System.ComponentModel.DataAnnotations;

namespace InternshipTrackerAPI.DTOs
{
    public class NoteDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public DateTime DateCreated { get; set; }
    }

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