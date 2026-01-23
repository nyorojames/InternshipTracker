using InternshipTrackerAPI.Data;
using InternshipTrackerAPI.Models;
using InternshipTrackerAPI.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace InternshipTrackerAPI.Repositories
{
    public class NoteRepository : INoteRepository
    {
        private readonly AppDbContext _context;

        public NoteRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Note?> GetByIdAsync(int id)
        {
            return await _context.Notes.FindAsync(id);
        }

        public async Task<List<Note>> GetByInternshipIdAsync(int internshipId)
        {
            return await _context.Notes
                .Where(n => n.InternshipId == internshipId)
                .OrderByDescending(n => n.DateCreated)
                .ToListAsync();
        }

        public async Task CreateAsync(Note note)
        {
            await _context.Notes.AddAsync(note);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Note note)
        {
            _context.Notes.Update(note);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
           var note = await _context.Notes.FindAsync(id);
            if (note != null)
              {
                _context.Notes.Remove(note);
                await _context.SaveChangesAsync();
            }
        }        
    }
}
