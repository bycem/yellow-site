using MediatR;

namespace Application.Commands.CreateVehicleListing;

public class CreateVehicleListingCommandHandler:IRequestHandler<CreateVehicleListingCommand,CreateVehicleListingCommandRepresentation>
{
    public Task<CreateVehicleListingCommandRepresentation> Handle(CreateVehicleListingCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}