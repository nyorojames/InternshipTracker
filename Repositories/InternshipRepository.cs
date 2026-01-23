using InternshipTrackerAPI.Data;
using InternshipTrackerAPI.Models;
using InternshipTrackerAPI.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace InternshipTrackerAPI.Repositories
{
    public class InternshipRepository : IInternshipRepository
    {
        private readonly AppDbContext _context;

        public InternshipRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Internship>> GetAllAsync(int userId)
        {
            return await _context.Internships
                .Where(i => i.UserId == userId)
                .ToListAsync();
        }

        public async Task<Internship?> GetByIdAsync(int id)
        {
            return await _context.Internships.FindAsync(id);
        }

        public async Task CreateAsync(Internship internship)
        {
            await _context.Internships.AddAsync(internship);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Internship internship)
        {
            _context.Internships.Update(internship);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var internship = await _context.Internships.FindAsync(id);
            if (internship != null)
            {
                _context.Internships.Remove(internship);
                await _context.SaveChangesAsync();
            }
        }

    }
}
