using Domain.Interfaces.Repositories;
using MediatR;

namespace Application.Commands.MakePayment
{
    public class MakePaymentCommandHandler : IRequestHandler<MakePaymentCommand, MakePaymentCommandRepresentation>
    {
        private readonly IOrderRepository _orderRepository;

        public MakePaymentCommandHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<MakePaymentCommandRepresentation> Handle(MakePaymentCommand request, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetById(request.OrderId);

            if (order == null)
            {
                throw new ArgumentException($"Order not found by following id: {request.OrderId}");
            }

            if (order.IsApproved)
            {
                throw new InvalidOperationException("Order already completed. You cannot make payment");
            }

            order.AddPayment(request.Amount,request.IsSuccess);

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
