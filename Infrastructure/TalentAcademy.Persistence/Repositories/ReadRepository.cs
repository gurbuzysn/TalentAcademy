using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TalentAcademy.Application.Repositories;
using TalentAcademy.Persistence.Context;

namespace TalentAcademy.Persistence.Repositories
{
    public class ReadRepository<T> : IReadRepository<T> where T : class, new()
    {
        private readonly TalentAcademyDbContext _context;

        public ReadRepository(TalentAcademyDbContext context)
        {
            _context = context;
        }
        public DbSet<T> Table => _context.Set<T>();

        public async Task<List<T>> GetAllAsync()
        {
            return await Table.AsNoTracking().ToListAsync();
        }

        public async Task<T?> GetByFilterAsync(Expression<Func<T, bool>> filter)
        {
            return await Table.AsNoTracking().SingleOrDefaultAsync(filter);
        }

        public async Task<T?> GetByIdAsync(Guid id)
        {
            return await Table.FindAsync(id);
        }
    }
}
