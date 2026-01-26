using InternshipTrackerAPI.DTOs;

public interface IUserService
{
    Task<UserDto> RegisterAsync(RegisterUserDto dto);
    Task<UserDto?> LoginAsync(LoginUserDto dto);
}