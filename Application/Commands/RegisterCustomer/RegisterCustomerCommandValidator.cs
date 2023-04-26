using FluentValidation;

namespace Application.Commands.RegisterCustomer;

public class RegisterCustomerCommandValidator : AbstractValidator<RegisterCustomerCommand>
{
    public RegisterCustomerCommandValidator()
    {
        RuleFor(x => x.Username)
            .NotEmpty()
            .MinimumLength(3)
            .MaximumLength(128);

        RuleFor(x => x.Email)
            .NotEmpty()
            .EmailAddress();

        RuleFor(x => x.FullName)
            .NotEmpty()
            .MaximumLength(128);

        RuleFor(x => x.UserId)
            .NotEmpty();
    }
}