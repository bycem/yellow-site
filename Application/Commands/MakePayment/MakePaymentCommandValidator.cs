using FluentValidation;

namespace Application.Commands.MakePayment;

public class MakePaymentCommandValidator : AbstractValidator<MakePaymentCommand>
{
    public MakePaymentCommandValidator()
    {
            
    }
}