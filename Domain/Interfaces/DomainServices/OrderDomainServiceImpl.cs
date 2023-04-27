using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.Models;

namespace Domain.Interfaces.DomainServices
{
    public class OrderDomainServiceImpl : IOrderDomainService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ICurrentCustomer _currentCustomer;

        public OrderDomainServiceImpl(
            IOrderRepository orderRepository,
            ICurrentCustomer currentCustomer)
        {
            _orderRepository = orderRepository;
            _currentCustomer = currentCustomer;
        }

        public async Task<Order> GetByIdForCurrentCustomerAsync(Guid id)
        {
            var order = await _orderRepository.GetByIdAsync(id);

            if (order == null)
            {
                throw new ArgumentException($"Order not found by following id: {id}");
            }

            var currentCustomer = await _currentCustomer.GetAsync();
            if (order.Buyer.Id != currentCustomer.Id)
            {
                throw new ArgumentException($"You cannot make payment for this order : {id}");
            }

            return order;
        }
    }
}
