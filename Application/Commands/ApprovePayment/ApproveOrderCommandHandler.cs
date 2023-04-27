using Domain.Interfaces.Repositories;
using MediatR;

namespace Application.Commands.ApprovePayment
{
    public class ApproveOrderCommandHandler : IRequestHandler<ApproveOrderCommand, ApproveOrderCommandRepresentation>
    {
        private readonly IOrderRepository _orderRepository;

        public ApproveOrderCommandHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<ApproveOrderCommandRepresentation> Handle(ApproveOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetById(request.OrderId);

            if (order == null)
                throw new ArgumentException($"Order not found by following id: {request.OrderId}");

            order.SetAsSold();

            await _orderRepository.UpdateAsync(order);

            return new ApproveOrderCommandRepresentation();
        }
    }
}
