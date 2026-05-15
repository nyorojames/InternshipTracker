using InternshipTrackerAPI.DTOs;

namespace InternshipTrackerAPI.Services.Contracts
{
    public interface INoteService
    {
        Task<List<NoteDto>?> GetByInternshipIdAsync(int internshipId, int userId);
        Task<NoteDto?> CreateAsync(CreateNoteDto dto, int userId);
    }
}
