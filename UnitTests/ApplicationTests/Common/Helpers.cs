using Domain.Models;

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
    }
}
