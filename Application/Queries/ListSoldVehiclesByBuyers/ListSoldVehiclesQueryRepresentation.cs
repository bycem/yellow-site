using Domain.Models;

namespace Application.Queries.ListSoldVehiclesByBuyers;

public class ListSoldVehiclesQueryRepresentation
{
    public ListSoldVehiclesQueryRepresentation(IEnumerable<SoldVehiclesOrderDto> orders)
    {
        Orders = orders;
    }

    public IEnumerable<SoldVehiclesOrderDto> Orders { get; set; }
}


public record SoldVehiclesOrderDto
{
    public string Brand { get; set; }
    public string Model { get; set; }
    public int ModelYear { get; set; }
    public int MileAge { get; set; }
    public DateTime? SellingDate { get; set; }
    public string BuyerName { get; set; }

    public static explicit operator SoldVehiclesOrderDto(Order order)
    {
        return new SoldVehiclesOrderDto
        {
            Brand = order.VehicleListing.VehicleValueObject.Brand,
            Model = order.VehicleListing.VehicleValueObject.Model,
            ModelYear = order.VehicleListing.VehicleValueObject.ModelYear,
            MileAge = order.VehicleListing.MileAge,
            SellingDate = order.SellingDate,
            BuyerName = order.Buyer.FullName
        };
    }
}