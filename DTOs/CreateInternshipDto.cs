using System.ComponentModel.DataAnnotations;
using InternshipTrackerAPI.Models;

namespace InternshipTrackerAPI.DTOs
{
    public class CreateInternshipDto
    {
        [Required]
        public string CompanyName { get; set; } = string.Empty;

        [Required]
        public string RoleTitle { get; set; } = string.Empty;

        public InternshipStatus Status { get; set; } = InternshipStatus.Applied;
        public string? JobUrl { get; set; }
    }
}