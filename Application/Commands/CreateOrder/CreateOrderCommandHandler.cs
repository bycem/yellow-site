using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.Models;
using MediatR;

namespace Application.Commands.CreateOrder
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, CreateOrderCommandRepresentation>
    {
        private readonly IOrderRepository _ordeRepository;
        private readonly IVehicleListingRepository _vehicleListingRepository;
        private readonly ICurrentCustomer _currentCustomer;

        public CreateOrderCommandHandler(
            IOrderRepository ordeRepository,
            IVehicleListingRepository vehicleListingRepository,
            ICurrentCustomer currentCustomer)
        {
            _ordeRepository = ordeRepository;
            _vehicleListingRepository = vehicleListingRepository;
            _currentCustomer = currentCustomer;
        }

        public async Task<CreateOrderCommandRepresentation> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var ordersByVehicle = await _ordeRepository.GetByVehicleIdAsync(request.VehicleId);

            var hasOrderWithPayment = ordersByVehicle.Any(x => x.TotalPaymentAmount > 0);
            if (hasOrderWithPayment)
            {
                throw new ArgumentException($"There is an active order for the vehicle listing");
            }

            var listing = await _vehicleListingRepository.GetById(request.VehicleId);
            if (listing == null || listing.IsSold)
            {
                throw new ArgumentException("Listing is not eligible for selling");
            }

            var seller = listing.Customer;
            var buyer = await _currentCustomer.GetAsync();

            if (buyer.Id == seller.Id)
            {
                throw new ArgumentException("You cannot buy your listing");
            }

            var orderId = await _ordeRepository.CreateAsync(new Order(listing, seller, buyer, listing.SellingPrice));

            return new CreateOrderCommandRepresentation { OrderId = orderId };
        }
    }
}
