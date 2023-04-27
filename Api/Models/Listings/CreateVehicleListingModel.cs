using Application.Commands.CreateVehicleListing;

namespace Api.Models.Listings
{
    public class CreateVehicleListingModel
    {
        public string? Brand { get; init; }
        public string? Model { get; init; }
        public int ModelYear { get; init; }

        public string Plate { get; init; }
        public int MileAge { get; init; }
        public decimal SellingPrice { get; init; }

        public static explicit operator CreateVehicleListingCommand(CreateVehicleListingModel model)
        {
            return new CreateVehicleListingCommand()
            {
                Brand = model.Brand,
                Plate = model.Plate,
                Model = model.Model,
                SellingPrice = model.SellingPrice,
                MileAge = model.MileAge,
                ModelYear = model.ModelYear
            };
        }
    }
}
