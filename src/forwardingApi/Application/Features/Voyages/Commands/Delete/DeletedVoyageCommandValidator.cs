using FluentValidation;

namespace Application.Features.Voyages.Commands.Delete;

public class DeleteVoyageCommandValidator : AbstractValidator<DeleteVoyageCommand>
{
    public DeleteVoyageCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}