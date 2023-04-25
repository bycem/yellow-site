using MediatR;

namespace Application.Commands.MakePayment;

public class MakePaymentCommand : IRequest<MakePaymentCommandRepresentation>, IRequest
{

}