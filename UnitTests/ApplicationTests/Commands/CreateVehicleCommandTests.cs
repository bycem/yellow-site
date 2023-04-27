using Application.Commands.CreateVehicleListing;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.Models;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using UnitTests.ApplicationTests.Common;

namespace UnitTests.ApplicationTests.Commands
{
    [TestFixture]
    public class CreateVehicleCommandTests
    {

        private CreateVehicleListingCommandHandler _handler;
        private Mock<IVehicleListingRepository> _vehicleRepositoryMock;
        private Mock<ICurrentCustomer> _currentCustomerMock;


        private readonly Customer _customer = Helpers.CreateCustomer();

        [SetUp]
        public void Setup()
        {
            _vehicleRepositoryMock = new Mock<IVehicleListingRepository>();
            _currentCustomerMock = new Mock<ICurrentCustomer>();
            _currentCustomerMock.Setup(x => x.GetAsync()).Returns(Task.FromResult(_customer));


            _handler = new CreateVehicleListingCommandHandler(_vehicleRepositoryMock.Object, _currentCustomerMock.Object);
        }

        [TestCase("Renault", "Fluence", 2012, 210000, "34TT2233", 1)]
        [TestCase("Ford", "Kangoo", 2024, 0, "34TT223", 1)]
        public async Task SuccessTests(
            string brand,
            string? model,
            int modelYear,
            int mileAge,
            string plate,
            decimal sellingPrice)
        {
            var createVehicleListingCommand = new CreateVehicleListingCommand()
            {
                Brand = brand,
                MileAge = mileAge,
                Model = model,
                ModelYear = modelYear,
                Plate = plate,
                SellingPrice = sellingPrice
            };

            var listingId = Guid.NewGuid();

            _vehicleRepositoryMock.Setup(x => x.HasAnyActiveListingAsync(plate)).Returns(Task.FromResult(false));
            _vehicleRepositoryMock.Setup(x => x.CreateAsync(It.IsAny<VehicleListing>())).Returns(Task.FromResult(listingId));

            var response = await _handler.Handle(createVehicleListingCommand, CancellationToken.None);

            response.ListingId.Should().Be(listingId);

            _vehicleRepositoryMock.Verify(x => x.HasAnyActiveListingAsync(plate), Times.Once);

            _currentCustomerMock.Verify(x => x.GetAsync(), Times.Once);

            _vehicleRepositoryMock.Verify(
                x => x.CreateAsync(It.Is<VehicleListing>(x =>
                    x.VehicleValueObject.Brand == brand &&
                    x.VehicleValueObject.Model == model &&
                    x.VehicleValueObject.ModelYear == modelYear &&
                    x.MileAge == mileAge &&
                    x.Plate == plate &&
                    x.SellingPrice == sellingPrice)),
                Times.Once);

            _vehicleRepositoryMock.VerifyNoOtherCalls();
        }


        [TestCase("Renault", "Fluence", 1900, 210000, "34TT2233", 1)]
        public async Task FailTest(
            string brand,
            string? model,
            int modelYear,
            int mileAge,
            string plate,
            decimal sellingPrice)
        {
            var createVehicleListingCommand = new CreateVehicleListingCommand()
            {
                Brand = brand,
                MileAge = mileAge,
                Model = model,
                ModelYear = modelYear,
                Plate = plate,
                SellingPrice = sellingPrice
            };

            _vehicleRepositoryMock.Setup(x => x.HasAnyActiveListingAsync(plate)).Returns(Task.FromResult(true));

            Assert.ThrowsAsync<ArgumentException>(async () =>
                {
                    await _handler.Handle(createVehicleListingCommand, CancellationToken.None);
                },
                $"There is active listing by following plate:{plate}");


            _vehicleRepositoryMock.Verify(x => x.HasAnyActiveListingAsync(plate), Times.Once);

            _currentCustomerMock.Verify(x => x.GetAsync(), Times.Never);

            _vehicleRepositoryMock.Verify(x => x.CreateAsync(It.IsAny<VehicleListing>()), Times.Never);
        }

    }
}
