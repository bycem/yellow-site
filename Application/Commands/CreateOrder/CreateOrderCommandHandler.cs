using MediatR;

namespace Application.Commands.CreateOrder
{
    public class CreateOrderCommandHandler:IRequestHandler<CreateOrderCommand,CreateOrderCommandRepresentation>
    {
        public Task<CreateOrderCommandRepresentation> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
