using FluentValidation;

namespace Application.Features.Ships.Commands.Update;

public class UpdateShipCommandValidator : AbstractValidator<UpdateShipCommand>
{
    public UpdateShipCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.ShipName).NotEmpty();
    }
}