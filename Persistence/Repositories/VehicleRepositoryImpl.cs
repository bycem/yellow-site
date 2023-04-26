using Domain.Interfaces.Repositories;
using Domain.Models;
using Microsoft.AspNetCore.Identity;

namespace Persistence.Repositories
{
    public class VehicleListingImpl : IVehicleListingRepository
    {
        private readonly ApplicationDbContext _context;

        public VehicleListingImpl(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<Guid> CreateAsync(VehicleListing listing)
        {
            _context.Add(new IdentityUser());
            throw new NotImplementedException();
        }
    }
}
