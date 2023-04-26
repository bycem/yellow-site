using Domain.Abstractions;

namespace Domain.Models;

public class Payment : BaseEntity
{
    public Payment() { }
    public Payment(decimal amount, bool isSuccess) : base(null, null)
    {
        if (amount <= 0)
            throw new ArgumentException("Amount cannot be lower or equal to zero");

        Amount = amount;
        IsSuccess = isSuccess;
    }
    public decimal Amount { get; protected set; }
    public bool IsSuccess { get; protected set; }

    public Guid OrderId { get; protected set; }
    public Order Order { get; protected set; }
}