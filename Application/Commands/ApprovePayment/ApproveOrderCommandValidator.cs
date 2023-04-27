using FluentValidation;

namespace Application.Commands.ApprovePayment;

public class ApproveOrderCommandValidator : AbstractValidator<ApproveOrderCommand>
{
    public ApproveOrderCommandValidator()
    {
        RuleFor(x => x.OrderId).NotEmpty();
    }
}