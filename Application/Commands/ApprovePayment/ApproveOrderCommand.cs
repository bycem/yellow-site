using MediatR;

namespace Application.Commands.ApprovePayment;

public class ApproveOrderCommand : IRequest<ApproveOrderCommandRepresentation>
{
    public Guid OrderId { get; set; }
}