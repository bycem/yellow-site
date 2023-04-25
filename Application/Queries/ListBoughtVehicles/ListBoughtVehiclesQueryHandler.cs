using MediatR;

namespace Application.Queries.ListBoughtVehicles
{
    public class ListBoughtVehiclesQueryHandler:IRequestHandler<ListBoughtVehiclesQuery,ListBoughtVehiclesQueryRepresentation>
    {
        public Task<ListBoughtVehiclesQueryRepresentation> Handle(ListBoughtVehiclesQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
