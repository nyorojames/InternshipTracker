using InternshipTrackerAPI.DTOs;
using InternshipTrackerAPI.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InternshipTrackerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class NotesController : ControllerBase
    {
        private readonly INoteService _service;

        public NotesController(INoteService service)
        {
            _service = service;
        }

        [HttpGet("internship/{internshipId}")]
        public async Task<IActionResult> GetNotesForInternship(int internshipId)
        {
            var userId = GetCurrentUserId();
            var notes = await _service.GetByInternshipIdAsync(internshipId, userId);

            if (notes == null) return NotFound();
            return Ok(notes);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateNoteDto dto)
        {
            var userId = GetCurrentUserId();
            var note = await _service.CreateAsync(dto, userId);

            if (note == null) return NotFound();
            return Ok(note);
        }

        private int GetCurrentUserId()
        {
            var idClaim = User.FindFirst("id");
            if (idClaim != null && int.TryParse(idClaim.Value, out int userId))
            {
                return userId;
            }

            throw new UnauthorizedAccessException("Invalid Token");
        }
    }
}
