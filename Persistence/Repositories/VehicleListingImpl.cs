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

        public async Task<VehicleListing> GetByPlateAsync(string plate)
        {
            var listing = await _context.VehicleListings.FirstOrDefaultAsync(x => x.Plate == plate);
            return listing;
        }
    }
}
