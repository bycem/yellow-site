using Domain.Models;
using FluentAssertions;
using NUnit.Framework;
using UnitTests.ApplicationTests.Common;

namespace UnitTests.DomainTests.Models
{
    [TestFixture]
    public class VehicleListingTests
    {

        [TestCase(0, 200000, "34TT2233")]
        [TestCase(9999999, 1, "34TT2233")]
        public void Should_Success_Create(int mileAge, decimal sellingPrice, string plate)
        {
            var listing = new VehicleListing(Helpers.CreateCustomer(), Helpers.CreateVehicleValueObject(), mileAge, sellingPrice, plate);

            listing.MileAge.Should().Be(mileAge);
            listing.SellingPrice.Should().Be(sellingPrice);
            listing.Plate.Should().Be(plate);
            listing.IsSold.Should().BeFalse();
            listing.UpdateDate.Should().BeNull();

            listing.IsEligibleToCreateOrder().Should().BeTrue();

            listing.SetAsSold();

            listing.IsSold.Should().BeTrue();

            listing.IsEligibleToCreateOrder().Should().BeFalse();
        }



        public void Should_Throw_Exception_When_Customer_Null()
        {

            Assert.Throws<ArgumentException>(() =>
            {
                var listing = new VehicleListing(null, Helpers.CreateVehicleValueObject(), 0, 1, "TT");
            }, $"{nameof(Customer)} should be provided");
        }

        /*
         *
         * Other Cases
         */
    }
}
