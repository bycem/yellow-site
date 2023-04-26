using MediatR;

namespace Application.Commands.CreateVehicleListing
{
    public class CreateVehicleListingCommand : IRequest<CreateVehicleListingCommandRepresentation>
    {
        public string? Brand { get; init; }
        public string? Model { get; init; }
        public int ModelYear { get; init; }

        public string Plate { get; init; }
        public int MileAge { get; init; }
        public decimal SellingPrice { get; init; }
    }
}
