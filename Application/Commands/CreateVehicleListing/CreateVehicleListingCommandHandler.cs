using Domain.Interfaces.Repositories;
using Domain.Models;
using Domain.ValueObjects;
using MediatR;

namespace Application.Commands.CreateVehicleListing;

public class CreateVehicleListingCommandHandler : IRequestHandler<CreateVehicleListingCommand, CreateVehicleListingCommandRepresentation>
{
    private readonly IVehicleListingRepository _vehicleRepository;

    public CreateVehicleListingCommandHandler(IVehicleListingRepository vehicleRepository)
    {
        _vehicleRepository = vehicleRepository;
    }

    public async Task<CreateVehicleListingCommandRepresentation> Handle(CreateVehicleListingCommand request, CancellationToken cancellationToken)
    {
        var id = await _vehicleRepository.CreateAsync(new VehicleListing(null,
            request.CustomerId,
            new VehicleValueObject(request.Brand,
                request.Model,
                request.ModelYear),
            request.MileAge,
            request.SellingPrice));

        return new CreateVehicleListingCommandRepresentation() { Id = id };

    }
}