using Domain.Abstractions;
#pragma warning disable CS8618

namespace Domain.Models;

public class Order : BaseEntity, IEntity
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

    public bool IsEligibleToApproveOrder => TotalPaymentAmount == SellingPrice;

    public void AddPayment(decimal amount, bool isSuccess)
    {
        if (amount <= 0)
            throw new ArgumentException("Payment amount cannot be equal to zero or lower", nameof(amount));

        var futureAmount = TotalPaymentAmount + amount;
        if (futureAmount > SellingPrice)
            throw new ArgumentException("Total Payment amount cannot be greater than SellingPrice", nameof(amount));


        _payments.Add(new Payment(null, amount, isSuccess));
    }

    public void SetAsSold()
    {
        if (IsApproved)
        {
            throw new ArgumentException("Already Approved");
        }
        else if (!IsEligibleToApproveOrder)
        {
            throw new ArgumentException("Not eligible to sold");
        }
        else
        {
            VehicleListing.SetAsSold();

            IsApproved = true;
            UpdateDate = DateTime.Now;
        }
    }
}