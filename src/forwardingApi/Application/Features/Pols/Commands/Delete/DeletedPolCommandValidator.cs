using FluentValidation;

namespace Application.Features.Pols.Commands.Delete;

public class DeletePolCommandValidator : AbstractValidator<DeletePolCommand>
{
    public DeletePolCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}