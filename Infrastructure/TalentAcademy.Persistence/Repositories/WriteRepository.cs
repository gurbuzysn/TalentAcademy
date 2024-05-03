using Microsoft.EntityFrameworkCore;
using TalentAcademy.Application.Repositories;
using TalentAcademy.Persistence.Context;

namespace TalentAcademy.Persistence.Repositories
{
    public class WriteRepository<T> : IWriteRepository<T> where T : class, new()
    {
        private readonly TalentAcademyDbContext _context;

        public WriteRepository(TalentAcademyDbContext context)
        {
            _context = context;
        }
        public DbSet<T> Table => _context.Set<T>();

        public async Task<T> CreateAsync(T entity)
        {
            await Table.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task RemoveAsync(T entity)
        {
            Table.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            Table.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
