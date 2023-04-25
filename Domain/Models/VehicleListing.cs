using Domain.Abstractions;
using Domain.ValueObjects;

namespace Domain.Models;

public class VehicleListing : BaseEntity, IAggregateRoot
{
    public VehicleListing(Guid? id,
        Guid customerId,
        VehicleValueObject vehicleValueObject,
        int mileAge,
        decimal sellingPrice,
        DateTime? createDate = null) : base(id,
        createDate)
    {
        if (customerId == Guid.Empty)
        {
            throw new ArgumentException("CustomerId cannot be empty guid", nameof(customerId));
        }

        if (mileAge < 1900 || mileAge > DateTime.Now.Year + 1)
        {
            throw new ArgumentOutOfRangeException(nameof(mileAge));
        }

        if (sellingPrice <= 0)
        {
            throw new ArgumentException("Sellingprice cannot be equal to zero or lower");
        }

        CustomerId = customerId;
        VehicleValueObject = vehicleValueObject;
        MileAge = mileAge;
        SellingPrice = sellingPrice;
    }


    public Guid CustomerId { get; protected set; }

    public VehicleValueObject VehicleValueObject { get; protected set; }

    public int MileAge { get; protected set; }

    public decimal SellingPrice { get; protected set; }

}