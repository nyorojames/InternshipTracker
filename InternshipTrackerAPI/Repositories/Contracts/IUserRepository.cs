using InternshipTrackerAPI.Models;

namespace InternshipTrackerAPI.Repositories.Contracts
{
    public interface IUserRepository
    {
        Task<User?> GetByEmailAsync(string email);
        Task<User?> GetByIdAsync(int id);
        Task<bool> UserExistsAsync(string email);
        Task CreateAsync(User user);
    }
}
