using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TalentAcademy.Application.Abstractions
{
    public interface IReadRepository<T> : IRepository<T> where T : class, new()
    {
        Task<List<T>> GetAllAsync();
        Task<T?> GetByIdAsync(Guid id);
        Task<T?> GetByFilterAsync(Expression<Func<T, bool>> filter);
    }
}
