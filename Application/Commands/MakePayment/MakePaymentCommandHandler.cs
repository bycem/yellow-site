using MediatR;

namespace Application.Commands.MakePayment
{
    public class MakePaymentCommandHandler:IRequestHandler<MakePaymentCommand,MakePaymentCommandRepresentation>
    {
        public Task<MakePaymentCommandRepresentation> Handle(MakePaymentCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
