using MediatR;

namespace Application.Commands.ApprovePayment
{
    public class ApprovePaymentCommandHandler:IRequestHandler<ApprovePaymentCommand,ApprovePaymentCommandRepresentation>
    {
        public Task<ApprovePaymentCommandRepresentation> Handle(ApprovePaymentCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
