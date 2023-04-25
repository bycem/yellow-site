using Domain.Abstractions;

namespace Domain.Models;

public class Payment : BaseEntity
{
    public Payment(Guid id,
        Customer customer,
        decimal amount,
        bool isSuccess,
        DateTime? createDate = null) : base(id, createDate)
    {
        if (amount <= 0)
            throw new ArgumentException("Amount cannot be lower or equal to zero");

        Customer = customer ?? throw new ArgumentException("Customer cannot be null");
        Amount = amount;
        IsSuccess = isSuccess;
    }

    public Customer Customer { get; protected set; }
    public decimal Amount { get; protected set; }
    public bool IsSuccess { get; protected set; }

}