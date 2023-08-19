using FluentValidation;

namespace Application.Features.Detentions.Commands.Create;

public class CreateDetentionCommandValidator : AbstractValidator<CreateDetentionCommand>
{
    public CreateDetentionCommandValidator()
    {
        RuleFor(c => c.Day).NotEmpty();
        RuleFor(c => c.Fee).NotEmpty();
    }
}