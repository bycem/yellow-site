using MediatR;

namespace Application.Commands.CreateOrder;

public class CreateOrderCommand : IRequest<CreateOrderCommandRepresentation>
{
    public Guid VehicleId { get; set; }
}