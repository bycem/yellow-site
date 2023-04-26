using MediatR;

namespace Application.Commands.RegisterCustomer
{
    public class RegisterCustomerCommandHandler:IRequestHandler<RegisterCustomerCommand,RegisterCustomerCommandRepresentation>
    {
        public Task<RegisterCustomerCommandRepresentation> Handle(RegisterCustomerCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
