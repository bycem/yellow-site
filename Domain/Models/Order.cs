using Domain.Abstractions;

namespace Domain.Models;

public class Order : BaseEntity, IAggregateRoot
{
    public Order(Guid id,
        VehicleListing vehicleListing,
        Customer seller,
        Customer buyer,
        decimal sellingPrice,
        List<Payment> payments,
        DateTime? createDate = null) : base(id, createDate)
    {
        VehicleListing = vehicleListing;
        Seller = seller;
        Buyer = buyer;
        SellingPrice = sellingPrice > 0 ? sellingPrice : throw new ArgumentException("Selling Price cannot be equal to zero or lower");
        _payments = payments;
    }

    public VehicleListing VehicleListing { get; protected set; }
    public Customer Seller { get; protected set; }
    public Customer Buyer { get; protected set; }
    public decimal SellingPrice { get; protected set; }
    public IReadOnlyCollection<Payment> Payments => _payments.AsReadOnly();
    private readonly List<Payment> _payments;
    
    public decimal TotalPaymentAmount => _payments.Where(x => x.IsSuccess).Sum(x => x.Amount);

    public decimal RemainingAmount => SellingPrice - TotalPaymentAmount;

    public bool IsEligibleToFinishOrder => TotalPaymentAmount == SellingPrice;


    public void MakePayment(Payment payment)
    {
        if (payment == null)
            throw new ArgumentNullException(nameof(payment));

        if (payment.Amount == 0)
            throw new ArgumentException("Payment amount cannot be equal to zero or lower", nameof(payment));

        var futureAmount = TotalPaymentAmount + payment.Amount;
        if (futureAmount > TotalPaymentAmount)
            throw new ArgumentException("Total Payment amount cannot be greater than SellingPrice", nameof(payment));


        _payments.Add(payment);
    }
}