using Domain.Abstractions;
using Domain.Enums;

namespace Domain.Entities;

public class Order : BaseEntity, IAggregateRoot
{
    public Order(Guid id,
        CustomerVehicle customerVehicle,
        Customer seller,
        Customer buyer,
        decimal sellingPrice,
        List<Payment> payments,
        DateTime? createDate = null) : base(id, createDate)
    {
        SellingPrice = sellingPrice;
        _payments = payments;
        CustomerVehicle = customerVehicle;
        Seller = seller;
        Buyer = buyer;
    }

    public CustomerVehicle CustomerVehicle { get; protected set; }
    public Customer Seller { get; protected set; }
    public Customer Buyer { get; protected set; }
    public decimal SellingPrice { get; protected set; }

    public E_TransactionStatus Status => Payments?.Where(x => x.IsSuccess).Sum(x => x.Amount) == SellingPrice
        ? E_TransactionStatus.PendingPayment
        : E_TransactionStatus.Succeed;

    public IReadOnlyCollection<Payment> Payments => _payments.AsReadOnly();
    private List<Payment> _payments { get; set; }

    public void AddPayment(Payment payment)
    {
        if (payment != null)
            _payments.Add(payment);
    }
}