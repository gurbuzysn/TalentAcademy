using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TalentAcademy.Application.Repositories;
using TalentAcademy.Persistence.Context;
using TalentAcademy.Persistence.Repositories;

namespace TalentAcademy.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<TalentAcademyDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped(typeof(IReadRepository<>), typeof(ReadRepository<>));
            services.AddScoped(typeof(IWriteRepository<>), typeof(WriteRepository<>));
        }
    }
}
