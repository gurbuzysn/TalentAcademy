namespace TalentAcademy.Application.Repositories
{
    public interface IWriteRepository<T> : IRepository<T> where T : class, new()
    {
        Task<T> CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task RemoveAsync(T entity);
    }
}
