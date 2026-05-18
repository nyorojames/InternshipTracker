namespace InternshipTrackerAPI.DTOs
{
    public class InternshipDto
    {
        public int Id { get; set; }
        public string CompanyName { get; set; } = string.Empty;
        public string RoleTitle { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty; 
        public DateTime DateApplied { get; set; }
        public string? JobUrl { get; set; }
        public string? Source { get; set; }
        public DateTime? Deadline { get; set; }
    }
}
