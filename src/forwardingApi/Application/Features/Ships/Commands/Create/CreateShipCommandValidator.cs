using FluentValidation;

namespace Application.Features.Ships.Commands.Create;

public class CreateShipCommandValidator : AbstractValidator<CreateShipCommand>
{
    public CreateShipCommandValidator()
    {
        RuleFor(c => c.ShipName).NotEmpty();
    }
}