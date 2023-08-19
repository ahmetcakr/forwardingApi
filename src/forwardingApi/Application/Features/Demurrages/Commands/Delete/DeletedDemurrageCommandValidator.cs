using FluentValidation;

namespace Application.Features.Demurrages.Commands.Delete;

public class DeleteDemurrageCommandValidator : AbstractValidator<DeleteDemurrageCommand>
{
    public DeleteDemurrageCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}