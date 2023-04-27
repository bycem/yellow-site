using Domain.Abstractions;
using Domain.Models;

namespace Domain.Interfaces.Repositories
{
    public interface IVehicleListingRepository:IRepository<VehicleListing>
    {
        public Task<bool> HasAnyActiveListingAsync(string plate);

        Task<List<VehicleListing>> GetActiveListingsAsync();
    }
}
