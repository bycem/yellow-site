using Domain.Abstractions;
#pragma warning disable CS8618

namespace Domain.Models;

public class Order : BaseEntity, IAggregateRoot
{
    protected internal Order() { }

    public Order(
        VehicleListing vehicleListing,
        Customer seller,
        Customer buyer,
        decimal sellingPrice) : base(null, null)
    {
        VehicleListing = vehicleListing;
        Seller = seller;
        Buyer = buyer;
        SellingPrice = sellingPrice > 0 ? sellingPrice : throw new ArgumentException("Selling Price cannot be equal to zero or lower");
        _payments = new List<Payment>();
    }

    public VehicleListing VehicleListing { get; protected set; }

    public Customer Seller { get; protected set; }

    public Customer Buyer { get; protected set; }

    public decimal SellingPrice { get; protected set; }

    public bool IsApproved { get; protected set; }

    public IReadOnlyCollection<Payment> Payments()
    {
        return _payments.AsReadOnly();
    }

    protected List<Payment> _payments { get; set; }

    public decimal TotalPaymentAmount => _payments.Where(x => x.IsSuccess).Sum(x => x.Amount);

    public decimal RemainingAmount => SellingPrice - TotalPaymentAmount;

    public bool IsEligibleToFinishOrder => TotalPaymentAmount == SellingPrice;

    public void MakePayment(Payment paymentValueObject)
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

    public void SetAsSold()
    {
        if (IsEligibleToFinishOrder)
        {
            IsApproved = true;
            UpdateDate = DateTime.Now;
        }
    }
}