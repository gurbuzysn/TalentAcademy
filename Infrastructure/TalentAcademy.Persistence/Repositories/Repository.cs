using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TalentAcademy.Application.Abstractions;
using TalentAcademy.Persistence.Context;

namespace TalentAcademy.Persistence.Repositories
{
    public class Repository<T> : IRepository<T> where T : class, new()
    {
        private readonly TalentAcademyDbContext _context;

        public Repository(TalentAcademyDbContext context)
        {
            _context = context;
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _context.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task<T?> GetByIdAsync(Guid id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public  Task<T?> GetByFilterAsync(Expression<Func<T, bool>> filter)
        {
            return _context.Set<T>().AsNoTracking().SingleOrDefaultAsync(filter);
        }

        public async Task<T> CreateAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task UpdateAsync(T entity)
        {
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
