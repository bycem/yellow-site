using Domain.Abstractions;
using Domain.ValueObjects;

namespace Domain.Models;

public class VehicleListing : BaseEntity, IAggregateRoot
{
    public VehicleListing(Guid id,
        Customer customer,
        VehicleValueObject vehicleValueObject,
        int mileAge,
        decimal sellingPrice,
        DateTime? createDate = null) : base(id,
        createDate)
    {
        Customer = customer;
        VehicleValueObject = vehicleValueObject;
        MileAge = mileAge;
        SellingPrice = sellingPrice;
    }


    public Customer Customer { get; protected set; }

    public VehicleValueObject VehicleValueObject { get; protected set; }

    public int MileAge { get; protected set; }

    public decimal SellingPrice { get; protected set; }

}