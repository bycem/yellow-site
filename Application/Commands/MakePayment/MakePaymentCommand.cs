using MediatR;

namespace Application.Commands.MakePayment;

public class MakePaymentCommand : IRequest<MakePaymentCommandRepresentation>
{
    public decimal Amount { get; set; }
}