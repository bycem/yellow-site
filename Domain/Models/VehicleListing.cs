using Domain.Abstractions;
using Domain.ValueObjects;

namespace Domain.Models;

public class VehicleListing : BaseEntity, IAggregateRoot
{
    public VehicleListing(Guid? id,
        Customer customer,
        VehicleValueObject vehicleValueObject,
        int mileAge,
        decimal sellingPrice, 
        string plate, 
        bool isSold = false,
        DateTime? createDate = null) : base(id, createDate)
    {
        if (mileAge < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(mileAge));
        }

        if (sellingPrice <= 0)
        {
            throw new ArgumentException("Sellingprice cannot be equal to zero or lower");
        }

        Customer = customer ?? throw new ArgumentException("CustomerId cannot be empty", nameof(customer));
        VehicleValueObject = vehicleValueObject;
        MileAge = mileAge;
        SellingPrice = sellingPrice;
        Plate = plate;
        IsSold = isSold;
    }


    public VehicleListing(Guid id,
        int mileAge,
        decimal sellingPrice,
        bool isSold,
        string plate,
        DateTime createDate) : this((Guid?)id, null, null, mileAge, sellingPrice, plate, isSold, createDate)
    {
    }

    public Customer Customer { get; protected set; }

    public VehicleValueObject VehicleValueObject { get; protected set; }

    public int MileAge { get; protected set; }

    public string Plate { get; protected set; }

    public decimal SellingPrice { get; protected set; }

    public bool IsSold { get; protected set; }

}