using Domain.Interfaces.Repositories;
using MediatR;

namespace Application.Queries.ListSoldVehiclesByBuyers
{
    public class ListSoldVehiclesQueryHandler : IRequestHandler<ListSoldVehiclesQuery, ListSoldVehiclesQueryRepresentation>
    {
        private readonly IOrderRepository _orderRepository;

        public ListSoldVehiclesQueryHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<ListSoldVehiclesQueryRepresentation> Handle(ListSoldVehiclesQuery request, CancellationToken cancellationToken)
        {
            var approvedOrders = await _orderRepository.ListAsync(x => x.IsApproved);
            var orderDtos = approvedOrders.Select(x => (SoldVehiclesOrderDto)x);

            return new ListSoldVehiclesQueryRepresentation(orderDtos);
        }
    }
}
