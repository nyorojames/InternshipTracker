using InternshipTrackerAPI.DTOs;

namespace InternshipTrackerAPI.Services.Contracts
{
    public interface IUserService
    {
        Task<UserDto> RegisterAsync(RegisterUserDto dto);
        Task<UserDto?> LoginAsync(LoginUserDto dto);
    }
}