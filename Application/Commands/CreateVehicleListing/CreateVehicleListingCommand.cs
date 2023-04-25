using MediatR;

namespace Application.Commands.CreateVehicleListing
{
    public class CreateVehicleListingCommand : IRequest<CreateVehicleListingCommandRepresentation>
    {
        public Guid CustomerId { get; set; }
        public string? Brand { get; init; }
        public string? Model { get; init; }
        public int ModelYear { get; init; }
        public int MileAge { get; init; }
        public int SellingPrice { get; init; }
    }
}
