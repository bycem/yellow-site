﻿using Domain.Interfaces.Repositories;
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

        var anyActiveListing = await _vehicleRepository.HasAnyActiveListingAsync(request.Plate);
        if (anyActiveListing)
        {
            throw new ArgumentException($"There is active listing by following plate:{request.Plate}");
        }

        var listing = new VehicleListing(
            currentCustomer,
            new VehicleValueObject(
                request.Brand,
                request.Model,
                request.ModelYear),
            request.MileAge,
            request.SellingPrice,
            request.Plate);

        var id = await _vehicleRepository.CreateAsync(listing);

        return new CreateVehicleListingCommandRepresentation() { Id = id };

    }
}