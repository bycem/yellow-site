﻿using Domain.Models;

namespace Domain.Interfaces.Repositories
{
    public interface IVehicleListingRepository
    {
        public Task<Guid> CreateAsync(VehicleListing listing);
    }
}
