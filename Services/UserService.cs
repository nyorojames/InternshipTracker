using InternshipTrackerAPI.DTOs;
using InternshipTrackerAPI.Models;
using InternshipTrackerAPI.Repositories.Contracts;

public class UserService : IUserService
{
    private readonly IUserRepository _repository;

    public UserService(IUserRepository repository)
    {
        _repository = repository;
    }

    public async Task<UserDto> RegisterAsync(RegisterUserDto dto)
    {
        // 1. Check if email exists
        if (await _repository.UserExistsAsync(dto.Email))
            throw new Exception("Email already registered");

        // 2. Hash Password (BCrypt handles salt automatically)
        var passwordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password);

        // 3. Create Entity
        var user = new User
        {
            Username = dto.Username,
            Email = dto.Email,
            PhoneNumber = dto.PhoneNumber,
            PasswordHash = passwordHash
        };

        await _repository.CreateAsync(user);

        // 4. Return DTO
        return new UserDto
        {
            Id = user.Id,
            Username = user.Username,
            Email = user.Email
            // Token will be generated in Controller later
        };
    }

    public async Task<UserDto?> LoginAsync(LoginUserDto dto)
    {
        var user = await _repository.GetByEmailAsync(dto.Email);
        if (user == null) return null;

        // 1. Verify Password
        bool isPasswordValid = BCrypt.Net.BCrypt.Verify(dto.Password, user.PasswordHash);
        if (!isPasswordValid) return null;

        // 2. Return User
        return new UserDto
        {
            Id = user.Id,
            Username = user.Username,
            Email = user.Email
        };
    }
}