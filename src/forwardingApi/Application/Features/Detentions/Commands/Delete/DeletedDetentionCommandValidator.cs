using FluentValidation;

namespace Application.Features.Detentions.Commands.Delete;

public class DeleteDetentionCommandValidator : AbstractValidator<DeleteDetentionCommand>
{
    public DeleteDetentionCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}