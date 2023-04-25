using Domain.Abstractions;

namespace Domain.Entities;

public class Payment : BaseEntity
{
    public Payment(Guid id,
        Customer customer,
        decimal amount,
        bool isSuccess,
        DateTime? createDate = null) : base(id, createDate)
    {
        Customer = customer;
        Amount = amount;
        IsSuccess = isSuccess;
    }

    public Customer Customer { get; protected set; }
    public decimal Amount { get; protected set; }
    public bool IsSuccess { get; protected set; }

}