using Domain.Abstractions;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Repositories;
using Persistence.Services.CurrentCustomer;

namespace Persistence
{
    public static class PersistenceConfiguration
    {
        public static IServiceCollection AddPersistenceConfig(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));

            services.AddScoped(typeof(IRepository<>), typeof(BaseRepositoryImpl<>));

            services.AddScoped<IVehicleListingRepository, VehicleListingImpl>();
            services.AddScoped<ICurrentCustomer, CurrentCustomerImpl>();

            return services;
        }
    }
}
