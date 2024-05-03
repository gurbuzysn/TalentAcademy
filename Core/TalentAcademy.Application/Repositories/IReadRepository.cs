using System.Linq.Expressions;

namespace TalentAcademy.Application.Repositories
{
    public interface IReadRepository<T> : IRepository<T> where T : class, new()
    {
        Task<List<T>> GetAllAsync();
        Task<T?> GetByIdAsync(Guid id);
        Task<T?> GetByFilterAsync(Expression<Func<T, bool>> filter);
    }
}
