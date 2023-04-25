using MediatR;

namespace Application.Queries.ListSoldVehiclesByBuyers
{
    public class ListSoldVehiclesByBuyersQueryHandler:IRequestHandler<ListSoldVehiclesByBuyersQuery,ListSoldVehiclesByBuyersQueryRepresentation>
    {
        public Task<ListSoldVehiclesByBuyersQueryRepresentation> Handle(ListSoldVehiclesByBuyersQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
