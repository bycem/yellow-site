using Domain.Abstractions;

namespace Domain.Models;

public class PaymentValueObject : BaseValueObject
{
    public PaymentValueObject(decimal amount, bool isSuccess)
    {
        if (amount <= 0)
            throw new ArgumentException("Amount cannot be lower or equal to zero");

        Amount = amount;
        IsSuccess = isSuccess;
    }
    public decimal Amount { get; protected set; }
    public bool IsSuccess { get; protected set; }

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Amount;
    }
}