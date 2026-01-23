using InternshipTrackerAPI.Models;

namespace InternshipTrackerAPI.Repositories.Contracts
{
    public interface IInternshipRepository
    {
        Task<List<Internship>> GetAllAsync(int userId);
        Task<Internship?> GetByIdAsync(int id);
        Task CreateAsync(Internship internship);
        Task UpdateAsync(Internship internship);
        Task DeleteAsync(int id);
    }
}
