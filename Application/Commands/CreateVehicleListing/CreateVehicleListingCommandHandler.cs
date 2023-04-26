using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.Models;
using Domain.ValueObjects;
using MediatR;

namespace Application.Commands.CreateVehicleListing;

public class CreateVehicleListingCommandHandler : IRequestHandler<CreateVehicleListingCommand, CreateVehicleListingCommandRepresentation>
{
    private readonly IVehicleListingRepository _vehicleRepository;
    private readonly ICurrentCustomer _currentCustomer;

    public CreateVehicleListingCommandHandler(
        IVehicleListingRepository vehicleRepository,
        ICurrentCustomer currentCustomer)
    {
        _vehicleRepository = vehicleRepository;
        _currentCustomer = currentCustomer;
    }

    public async Task<CreateVehicleListingCommandRepresentation> Handle(CreateVehicleListingCommand request, CancellationToken cancellationToken)
    {
        var currentCustomer = await _currentCustomer.Get();

        var id = await _vehicleRepository.CreateAsync(new VehicleListing(null,
            currentCustomer,
            new VehicleValueObject(
                request.Brand,
                request.Model,
                request.ModelYear),
            request.MileAge,
            request.SellingPrice));

        return new CreateVehicleListingCommandRepresentation() { Id = id };

    }
}