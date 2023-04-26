using Domain.Interfaces.Repositories;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories
{
    public class VehicleListingImpl : IVehicleListingRepository
    {
        private readonly ApplicationDbContext _context;

        public VehicleListingImpl(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> CreateAsync(VehicleListing listing)
        {
            _context.VehicleListings.Add(listing);
            await _context.SaveChangesAsync();
            return listing.Id;
        }

        public async Task<bool> HasAnyActiveListingAsync(string plate)
        {
            var hasAnyActiveListing = await _context.VehicleListings.AnyAsync(x => x.Plate == plate && !x.IsSold);
            return hasAnyActiveListing;
        }
    }
}
