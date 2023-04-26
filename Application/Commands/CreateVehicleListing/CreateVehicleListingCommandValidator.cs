using FluentValidation;

namespace Application.Commands.CreateVehicleListing;

public class CreateVehicleListingCommandValidator : AbstractValidator<CreateVehicleListingCommand>
{
    public CreateVehicleListingCommandValidator()
    {
        RuleFor(x => x.Brand).NotEmpty().MaximumLength(64);
        RuleFor(x => x.Model).NotEmpty().MaximumLength(256);
        RuleFor(x => x.MileAge).GreaterThanOrEqualTo(0);
        RuleFor(x => x.Plate).NotEmpty().MinimumLength(7).MaximumLength(8);
        RuleFor(x => x.SellingPrice).GreaterThan(0);
        RuleFor(x => x.ModelYear).GreaterThan(1900).LessThanOrEqualTo(DateTime.Now.Year + 1);
    }
}