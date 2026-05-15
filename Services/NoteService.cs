using InternshipTrackerAPI.DTOs;
using InternshipTrackerAPI.Models;
using InternshipTrackerAPI.Repositories.Contracts;
using InternshipTrackerAPI.Services.Contracts;

namespace InternshipTrackerAPI.Services
{
    public class NoteService : INoteService
    {
        private readonly INoteRepository _noteRepository;
        private readonly IInternshipRepository _internshipRepository;

        public NoteService(INoteRepository noteRepository, IInternshipRepository internshipRepository)
        {
            _noteRepository = noteRepository;
            _internshipRepository = internshipRepository;
        }

        public async Task<List<NoteDto>?> GetByInternshipIdAsync(int internshipId, int userId)
        {
            if (!await UserOwnsInternshipAsync(internshipId, userId))
                return null;

            var notes = await _noteRepository.GetByInternshipIdAsync(internshipId);

            return notes.Select(n => new NoteDto
            {
                Id = n.Id,
                Title = n.Title,
                Content = n.Content,
                DateCreated = n.DateCreated
            }).ToList();
        }

        public async Task<NoteDto?> CreateAsync(CreateNoteDto dto, int userId)
        {
            if (!await UserOwnsInternshipAsync(dto.InternshipId, userId))
                return null;

            var note = new Note
            {
                InternshipId = dto.InternshipId,
                Title = dto.Title,
                Content = dto.Content,
                DateCreated = DateTime.UtcNow
            };

            await _noteRepository.CreateAsync(note);

            return new NoteDto
            {
                Id = note.Id,
                Title = note.Title,
                Content = note.Content,
                DateCreated = note.DateCreated
            };
        }

        private async Task<bool> UserOwnsInternshipAsync(int internshipId, int userId)
        {
            var internship = await _internshipRepository.GetByIdAsync(internshipId);
            return internship != null && internship.UserId == userId;
        }
    }
}
