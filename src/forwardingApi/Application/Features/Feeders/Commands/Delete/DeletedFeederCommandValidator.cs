using FluentValidation;

namespace Application.Features.Feeders.Commands.Delete;

public class DeleteFeederCommandValidator : AbstractValidator<DeleteFeederCommand>
{
    public DeleteFeederCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}