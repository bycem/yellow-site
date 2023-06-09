﻿using Domain.Abstractions;
using Domain.ValueObjects;
#pragma warning disable CS8618

namespace Domain.Models;

public class VehicleListing : BaseEntity, IEntity
{
    protected internal VehicleListing() : base() { }


    public VehicleListing(
        Customer customer,
        VehicleValueObject vehicleValueObject,
        int mileAge,
        decimal sellingPrice,
        string plate) : base(null, null)
    {

        if (customer == null)
        {
            throw new ArgumentException($"{nameof(Customer)} should be provided");
        }

        if (vehicleValueObject == null)
        {
            throw new ArgumentException($"{nameof(VehicleValueObject)} should be provided");
        }

        if (mileAge < 0)
        {
            throw new ArgumentException(nameof(mileAge));
        }

        if (sellingPrice <= 0)
        {
            throw new ArgumentException("Sellingprice cannot be equal to zero or lower");
        }

        if (string.IsNullOrEmpty(plate) || plate.Length < 7 || plate.Length > 8)
        {
            throw new ArgumentException($"{nameof(Plate)} length must be between 7 to 8 characters");
        }

        Customer = customer ?? throw new ArgumentException("CustomerId cannot be empty", nameof(customer));
        VehicleValueObject = vehicleValueObject;
        MileAge = mileAge;
        SellingPrice = sellingPrice;
        Plate = plate;
    }



    public Customer Customer { get; protected set; }

    public VehicleValueObject VehicleValueObject { get; protected set; }

    public int MileAge { get; protected set; }

    public string Plate { get; protected set; }

    public decimal SellingPrice { get; protected set; }

    public bool IsSold { get; protected set; }

    public void SetAsSold()
    {
        if (IsSold)
            throw new ArgumentException("Already Sold", nameof(IsSold));

        IsSold = true;
        UpdateDate = DateTime.Now;
    }

    public bool IsEligibleToCreateOrder()
    {
        return !IsSold;
    }
}