using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using MediatR;

namespace Application.Queries.ListBoughtVehicles
{
    public class ListBoughtVehiclesQueryHandler : IRequestHandler<ListBoughtVehiclesQuery, ListBoughtVehiclesQueryRepresentation>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ICurrentCustomer _currentCustomer;

        public ListBoughtVehiclesQueryHandler(
            IOrderRepository orderRepository,
            ICurrentCustomer currentCustomer)
        {
            _orderRepository = orderRepository;
            _currentCustomer = currentCustomer;
        }

        public async Task<ListBoughtVehiclesQueryRepresentation> Handle(ListBoughtVehiclesQuery request, CancellationToken cancellationToken)
        {
            var currentCustomer = await _currentCustomer.GetAsync();
            var orders = await _orderRepository.ListAsync(x => x.Buyer.Id == currentCustomer.Id);
            var orderDtos = orders.OrderByDescending(x => x.SellingDate).Select(x => (BoughtVehiclesOrderDto)x).ToList();

            return new ListBoughtVehiclesQueryRepresentation(orderDtos);
        }
    }
}
