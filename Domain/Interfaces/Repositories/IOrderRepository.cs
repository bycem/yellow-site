using Domain.Abstractions;
using Domain.Models;

namespace Domain.Interfaces.Repositories
{
    public interface IOrderRepository : IRepository<Order>
    {
       Task<List<Order>> GetByVehicleIdAsync(Guid vehicleId);
    }
}
