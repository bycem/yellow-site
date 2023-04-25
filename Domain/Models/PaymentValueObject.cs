using Domain.Abstractions;

namespace Domain.Models;

public class Payment : BaseValueObject
{
    public Payment(decimal amount, bool isSuccess)
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