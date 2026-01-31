using InternshipTrackerAPI.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

[Route("api/[controller]")]
[ApiController]
[Authorize] 
public class InternshipsController : ControllerBase
{
    private readonly IInternshipService _service;

    public InternshipsController(IInternshipService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var userId = GetCurrentUserId();
        var internships = await _service.GetAllAsync(userId);
        return Ok(internships);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var userId = GetCurrentUserId();
        var internship = await _service.GetByIdAsync(id, userId);

        if (internship == null) return NotFound();
        return Ok(internship);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateInternshipDto dto)
    {
        var userId = GetCurrentUserId();
        var createdInternship = await _service.CreateAsync(dto, userId);

        return CreatedAtAction(nameof(GetById), new { id = createdInternship.Id }, createdInternship);
    }

    // --- HELPER: EXTRACT USER ID FROM TOKEN ---
    private int GetCurrentUserId()
    {
        // This "id" claim was put into the token in AuthController
        var idClaim = User.FindFirst("id");
        if (idClaim != null && int.TryParse(idClaim.Value, out int userId))
        {
            return userId;
        }
        throw new UnauthorizedAccessException("Invalid Token");
    }
}