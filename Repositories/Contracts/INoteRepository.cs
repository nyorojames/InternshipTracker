using InternshipTrackerAPI.Models;

namespace InternshipTrackerAPI.Repositories.Contracts
{
    public interface INoteRepository
    {
        Task<List<Note>> GetByInternshipIdAsync(int internshipId);

        Task<Note?> GetByIdAsync(int id);
        Task CreateAsync(Note note);
        Task UpdateAsync(Note note);
        Task DeleteAsync(int id);
    }
}
