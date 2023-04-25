using Domain.Abstractions;

namespace Domain.Models;

public class Order : BaseEntity, IAggregateRoot
{
    public Order(Guid id,
        VehicleListing vehicleListing,
        Customer seller,
        Customer buyer,
        decimal sellingPrice,
        List<PaymentValueObject> payments, bool isApproved, DateTime? createDate = null) : base(id, createDate)
    {
        VehicleListing = vehicleListing;
        Seller = seller;
        Buyer = buyer;
        SellingPrice = sellingPrice > 0 ? sellingPrice : throw new ArgumentException("Selling Price cannot be equal to zero or lower");
        _payments = payments;
        IsApproved = isApproved;
    }

    public VehicleListing VehicleListing { get; protected set; }
    public Customer Seller { get; protected set; }
    public Customer Buyer { get; protected set; }
    public decimal SellingPrice { get; protected set; }
    public bool IsApproved { get; protected set; }

    public IReadOnlyCollection<PaymentValueObject> Payments => _payments.AsReadOnly();
    private readonly List<PaymentValueObject> _payments;
    
    public decimal TotalPaymentAmount => _payments.Where(x => x.IsSuccess).Sum(x => x.Amount);

    public decimal RemainingAmount => SellingPrice - TotalPaymentAmount;

    public bool IsEligibleToFinishOrder => TotalPaymentAmount == SellingPrice;

    public void MakePayment(PaymentValueObject paymentValueObject)
    {
        if (paymentValueObject == null)
            throw new ArgumentNullException(nameof(paymentValueObject));

        if (paymentValueObject.Amount == 0)
            throw new ArgumentException("Payment amount cannot be equal to zero or lower", nameof(paymentValueObject));

        var futureAmount = TotalPaymentAmount + paymentValueObject.Amount;
        if (futureAmount > TotalPaymentAmount)
            throw new ArgumentException("Total Payment amount cannot be greater than SellingPrice", nameof(paymentValueObject));


        _payments.Add(paymentValueObject);
    }
}