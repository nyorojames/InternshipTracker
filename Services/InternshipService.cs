using InternshipTrackerAPI.DTOs;
using InternshipTrackerAPI.Models;
using InternshipTrackerAPI.Repositories.Contracts;

public class InternshipService : IInternshipService
{
    private readonly IInternshipRepository _repository;

    public InternshipService(IInternshipRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<InternshipDto>> GetAllAsync(int userId)
    {
        var internships = await _repository.GetAllAsync(userId);

        // Manual Mapping (Entity -> DTO)
        return internships.Select(i => new InternshipDto
        {
            Id = i.Id,
            CompanyName = i.CompanyName,
            RoleTitle = i.RoleTitle,
            Status = i.Status.ToString(), // Convert Enum to String
            DateApplied = i.DateApplied,
            JobUrl = i.JobUrl
        }).ToList();
    }

    public async Task<InternshipDto?> GetByIdAsync(int id, int userId)
    {
        var internship = await _repository.GetByIdAsync(id);

        // Security Check: Does this belong to the user?
        if (internship == null || internship.UserId != userId)
            return null;

        return new InternshipDto
        {
            Id = internship.Id,
            CompanyName = internship.CompanyName,
            RoleTitle = internship.RoleTitle,
            Status = internship.Status.ToString(),
            DateApplied = internship.DateApplied,
            JobUrl = internship.JobUrl
        };
    }

    public async Task<InternshipDto> CreateAsync(CreateInternshipDto dto, int userId)
    {
        var internship = new Internship
        {
            UserId = userId,
            CompanyName = dto.CompanyName,
            RoleTitle = dto.RoleTitle,
            Status = dto.Status,
            JobUrl = dto.JobUrl,
            DateApplied = DateTime.UtcNow,
            IsActive = true
        };

        await _repository.CreateAsync(internship);

        return new InternshipDto
        {
            Id = internship.Id,
            CompanyName = internship.CompanyName,
            RoleTitle = internship.RoleTitle,
            Status = internship.Status.ToString(),
            DateApplied = internship.DateApplied,
            JobUrl = internship.JobUrl
        };
    }
}