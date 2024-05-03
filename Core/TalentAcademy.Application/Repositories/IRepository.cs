using Microsoft.EntityFrameworkCore;

namespace TalentAcademy.Application.Repositories
{
    public interface IRepository<T> where T : class, new()
    {
        DbSet<T> Table { get; }
    }
}
