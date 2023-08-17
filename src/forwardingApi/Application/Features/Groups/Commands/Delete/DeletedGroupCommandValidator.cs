using FluentValidation;

namespace Application.Features.Groups.Commands.Delete;

public class DeleteGroupCommandValidator : AbstractValidator<DeleteGroupCommand>
{
    public DeleteGroupCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}