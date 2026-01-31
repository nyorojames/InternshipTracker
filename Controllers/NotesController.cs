using InternshipTrackerAPI.DTOs;
using InternshipTrackerAPI.Models;
using InternshipTrackerAPI.Repositories.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class NotesController : ControllerBase
{
    private readonly INoteRepository _repository;

    public NotesController(INoteRepository repository)
    {
        _repository = repository;
    }

    [HttpGet("internship/{internshipId}")]
    public async Task<IActionResult> GetNotesForInternship(int internshipId)
    {
        var notes = await _repository.GetByInternshipIdAsync(internshipId);

        var noteDtos = notes.Select(n => new NoteDto
        {
            Id = n.Id,
            Title = n.Title,
            Content = n.Content,
            DateCreated = n.DateCreated
        });

        return Ok(noteDtos);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateNoteDto dto)
    {
        var note = new Note
        {
            InternshipId = dto.InternshipId,
            Title = dto.Title,
            Content = dto.Content,
            DateCreated = DateTime.UtcNow
        };

        await _repository.CreateAsync(note);
        return Ok(note);
    }
}