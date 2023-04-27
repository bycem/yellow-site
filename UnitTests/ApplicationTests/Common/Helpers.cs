using Domain.Models;
using Domain.ValueObjects;

namespace UnitTests.ApplicationTests.Common
{
    public static class Helpers
    {
        public static Guid CustomerId = Guid.NewGuid();
        public static string Username = "USER";
        public static string FullName = "FULL NAME";


        public static Customer CreateCustomer()
        {
            return new Customer(CustomerId, Username, "test@example.com", FullName, "000", DateTime.Now);
        }

        public static VehicleValueObject CreateVehicleValueObject()
        {
            return new VehicleValueObject("Renault", "Fluence", 2012);
        }

        public static VehicleListing CreateListing()
        {
            return new VehicleListing(Helpers.CreateCustomer(), Helpers.CreateVehicleValueObject(), 1, 1, "34TK2233");
        }
    }
}
