using InternshipTrackerAPI.DTOs;

namespace InternshipTrackerAPI.Services.Contracts
{
    public interface IInternshipService
    {
        Task<List<InternshipDto>> GetAllAsync(int userId);
        Task<InternshipDto?> GetByIdAsync(int id, int userId); 
        Task<InternshipDto> CreateAsync(CreateInternshipDto dto, int userId);
    }
}