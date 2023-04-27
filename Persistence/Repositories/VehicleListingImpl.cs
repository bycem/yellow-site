using Domain.Interfaces.Repositories;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories
{
    public class VehicleListingImpl : BaseRepositoryImpl<VehicleListing>, IVehicleListingRepository
    {
        private readonly ApplicationDbContext _context;

        public VehicleListingImpl(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<bool> HasAnyActiveListingAsync(string plate)
        {
            var hasAnyActiveListing = await _context.VehicleListings.AnyAsync(x => x.Plate == plate && !x.IsSold);
            return hasAnyActiveListing;
        }

        public async Task<List<VehicleListing>> GetActiveListingsAsync()
        {
            var activeListings = await _context.VehicleListings
                .Where(x => !x.IsSold).ToListAsync();
            return activeListings;
        }
    }
}
