using MediatR;

namespace Application.Commands.ApprovePayment;

public class ApprovePaymentCommand : IRequest<ApprovePaymentCommandRepresentation>
{
    public Guid CustomerId { get; set; }
    public Guid OrderId { get; set; }
}