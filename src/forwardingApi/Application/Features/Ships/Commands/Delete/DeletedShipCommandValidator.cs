using FluentValidation;

namespace Application.Features.Ships.Commands.Delete;

public class DeleteShipCommandValidator : AbstractValidator<DeleteShipCommand>
{
    public DeleteShipCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}