using Domain.Abstractions;
using Domain.ValueObjects;

namespace Domain.Entities;

public class CustomerVehicle:BaseEntity
{
    public CustomerVehicle(Guid id,
        Customer customer,
        Vehicle vehicle,
        int mileAge,
        decimal sellingPrice,
        DateTime? createDate = null) : base(id,
        createDate)
    {
        Customer = customer;
        Vehicle = vehicle;
        MileAge = mileAge;
        SellingPrice = sellingPrice;
    }
   

    public Customer Customer { get; protected set; }

    public Vehicle Vehicle { get; protected set; }

    public int MileAge { get; protected set; }

    public decimal SellingPrice { get; protected set; }

}