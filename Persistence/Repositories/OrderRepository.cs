using Domain.Interfaces.Repositories;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories
{
    public class OrderRepository : BaseRepositoryImpl<Order>, IOrderRepository
    {
        public OrderRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<List<Order>> GetByVehicleIdAsync(Guid vehicleId)
        {
            var order = await _dbSet.Where(x => x.VehicleListing.Id == vehicleId).ToListAsync();
            return order;
        }

        public async Task UpdateOrderAsync(Order entity)
        {
            _context.Orders.Update(entity);

            await _context.SaveChangesAsync();
        }
    }
}
