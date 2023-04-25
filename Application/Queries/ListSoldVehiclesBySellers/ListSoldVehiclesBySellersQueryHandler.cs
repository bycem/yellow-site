using MediatR;

namespace Application.Queries.ListSoldVehiclesBySellers
{
    public class ListSoldVehiclesBySellersQueryHandler:IRequestHandler<ListSoldVehiclesBySellersQuery, ListSoldVehiclesBySellersQueryRepresentation>
    {
        public Task<ListSoldVehiclesBySellersQueryRepresentation> Handle(ListSoldVehiclesBySellersQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
