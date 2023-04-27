using Domain.Interfaces.DomainServices;
using Domain.Interfaces.Repositories;
using MediatR;

namespace Application.Commands.ApprovePayment
{
    public class ApproveOrderCommandHandler : IRequestHandler<ApproveOrderCommand, ApproveOrderCommandRepresentation>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderDomainService _orderDomainService;

        public ApproveOrderCommandHandler(
            IOrderRepository orderRepository,
            IOrderDomainService orderDomainService)
        {
            _orderRepository = orderRepository;
            _orderDomainService = orderDomainService;
        }

        public async Task<ApproveOrderCommandRepresentation> Handle(ApproveOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await _orderDomainService.GetByIdForCurrentCustomerAsync(request.OrderId);

            order.SetAsSold();

            await _orderRepository.UpdateAsync(order);

            return new ApproveOrderCommandRepresentation() { Ok = true };
        }
    }
}
