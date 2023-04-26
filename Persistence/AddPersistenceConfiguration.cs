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

            services.AddScoped<IVehicleListingRepository, VehicleListingImpl>();
            services.AddScoped<ICustomerRepository, CustomerRepositoryImpl>();
            services.AddScoped<ICurrentCustomer, CurrentCustomerImpl>();

            return services;
        }
    }
}
