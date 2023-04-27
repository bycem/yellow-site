using MediatR;

namespace Application.Commands.MakePayment;

public class MakePaymentCommand : IRequest<MakePaymentCommandRepresentation>
{
    public Guid OrderId { get; set; }
    public decimal Amount { get; set; }
    public bool IsSuccess { get; set; }
}