using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using TalentAcademy.Application.Features;

namespace TalentAcademy.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddScoped(typeof(GeneralResponse));
        }
    }
}
