using FluentValidation;

namespace Application.Commands.MakePayment;

public class MakePaymentCommandValidator : AbstractValidator<MakePaymentCommand>
{
    public MakePaymentCommandValidator()
    {
        RuleFor(x => x.Amount).GreaterThan(0);
        RuleFor(x => x.OrderId).NotEmpty();
    }
}