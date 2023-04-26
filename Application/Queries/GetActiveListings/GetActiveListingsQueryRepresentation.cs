﻿using Domain.Models;

namespace Application.Queries.GetActiveListings;

public class GetActiveListingsQueryRepresentation
{
    public GetActiveListingsQueryRepresentation(IEnumerable<ListingDto> listings)
    {
        Listings = listings;
    }

    public IEnumerable<ListingDto> Listings { get; init; }
}


public record ListingDto
{
    public static explicit operator ListingDto(VehicleListing vehicleListing)
    {
        return new ListingDto
        {
            Brand = vehicleListing.VehicleValueObject.Brand,
            Model = vehicleListing.VehicleValueObject.Model,
            ModelYear = vehicleListing.VehicleValueObject.ModelYear,
            MileAge = vehicleListing.MileAge,
            SellingPrice = vehicleListing.SellingPrice
        };
    }

    public int MileAge { get; set; }
    public string Brand { get; set; }
    public string Model { get; set; }
    public int ModelYear { get; set; }
    public decimal SellingPrice { get; set; }
}