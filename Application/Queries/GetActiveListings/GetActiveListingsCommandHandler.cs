using Domain.Interfaces.Repositories;
using Domain.Models;
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
            IEnumerable<VehicleListing> activeListings = await _vehicleListingRepository.GetActiveListingsAsync();
            activeListings = activeListings.OrderByDescending(x => x.UpdateDate ?? x.CreateDate);

            var listingDtos = activeListings.Select(listing => (ListingDto)listing);

            return new GetActiveListingsQueryRepresentation(listingDtos);
        }
    }
}
