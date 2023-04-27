using Domain.Interfaces.DomainServices;
using Domain.Interfaces.Repositories;
using MediatR;

namespace Application.Commands.MakePayment
{
    public class MakePaymentCommandHandler : IRequestHandler<MakePaymentCommand, MakePaymentCommandRepresentation>
    {
        private readonly IOrderDomainService _orderDomainService;
        private readonly IOrderRepository _orderRepository;
    
        public MakePaymentCommandHandler(
            IOrderDomainService orderDomainService, 
            IOrderRepository orderRepository)
        {
            _orderDomainService = orderDomainService;
            _orderRepository = orderRepository;
        }

        public async Task<MakePaymentCommandRepresentation> Handle(MakePaymentCommand request, CancellationToken cancellationToken)
        {
            var order = await _orderDomainService.GetByIdForCurrentCustomerAsync(request.OrderId);

            if (order.IsApproved)
            {
                throw new InvalidOperationException("Order already completed. You cannot make payment");
            }

            order.AddPayment(request.Amount, request.IsSuccess);

            await _orderRepository.UpdateOrderAsync(order);

            return new MakePaymentCommandRepresentation()
            {
                TotalPaidAmount = order.TotalPaymentAmount,
                RemainingAmount = order.RemainingAmount,
                IsEligibleToApprove = order.IsEligibleToApproveOrder
            };
        }
    }
}
