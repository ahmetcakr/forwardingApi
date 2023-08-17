using FluentValidation;

namespace Application.Features.Groups.Commands.Create;

public class CreateGroupCommandValidator : AbstractValidator<CreateGroupCommand>
{
    public CreateGroupCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty();
    }
}