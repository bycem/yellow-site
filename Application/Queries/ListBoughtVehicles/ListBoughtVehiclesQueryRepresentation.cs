﻿using Domain.Models;

namespace Application.Queries.ListBoughtVehicles;

public class ListBoughtVehiclesQueryRepresentation
{
    public ListBoughtVehiclesQueryRepresentation(List<BoughtVehiclesOrderDto> orders)
    {
        Orders = orders;
    }

    public List<BoughtVehiclesOrderDto> Orders { get; set; }
}

public record BoughtVehiclesOrderDto
{
    public string Brand { get; set; }
    public string Model { get; set; }
    public int ModelYear { get; set; }
    public int MileAge { get; set; }
    public DateTime? SellingDate { get; set; }

    public static explicit operator BoughtVehiclesOrderDto(Order order)
    {
        return new BoughtVehiclesOrderDto
        {
            Brand = order.VehicleListing.VehicleValueObject.Brand,
            Model = order.VehicleListing.VehicleValueObject.Model,
            ModelYear = order.VehicleListing.VehicleValueObject.ModelYear,
            MileAge = order.VehicleListing.MileAge,
            SellingDate = order.SellingDate
        };
    }
}