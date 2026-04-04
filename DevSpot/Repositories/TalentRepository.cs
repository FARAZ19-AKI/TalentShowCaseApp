using DevSpot.Data;
using Microsoft.EntityFrameworkCore;

namespace DevSpot.Repositories
{
    public class TalentRepository : IRepository<Talent>
    {
        private readonly ApplicationDbContext _context;
        public TalentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Talent entity)
        {
            await _context.Talents.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var Talent = await _context.Talents.FindAsync(id);

            if (Talent == null)
            {
                throw new KeyNotFoundException();
            }

            _context.Talents.Remove(Talent);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Talent>> GetAllAsync()
        {
            return await _context.Talents.ToListAsync();
        }

        public async Task<Talent> GetByIdAsync(int id)
        {
            var Talent = await _context.Talents.FindAsync(id);

            if (Talent == null)
            {
                throw new KeyNotFoundException();
            }

            return Talent;
        }

        public async Task UpdateAsync(Talent entity)
        {
            _context.Talents.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
