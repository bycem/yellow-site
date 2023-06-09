﻿using Domain.Interfaces.Repositories;
using MediatR;

namespace Application.Queries.GetActiveListings
{
    public class GetActiveListingsQueryHandler : IRequestHandler<GetActiveListingsQuery, GetActiveListingsQueryRepresentation>
    {
        private readonly IVehicleListingRepository _vehicleListingRepository;

        public GetActiveListingsQueryHandler(IVehicleListingRepository vehicleListingRepository)
        {
            _vehicleListingRepository = vehicleListingRepository;
        }

        public async Task<GetActiveListingsQueryRepresentation> Handle(GetActiveListingsQuery request, CancellationToken cancellationToken)
        {
            var activeListings = await _vehicleListingRepository.GetActiveListingsAsync();

            var listingDtos = activeListings
                .OrderByDescending(x => x.UpdateDate ?? x.CreateDate)
                .Select(listing => (ListingDto)listing);

            return new GetActiveListingsQueryRepresentation(listingDtos);
        }
    }
}
