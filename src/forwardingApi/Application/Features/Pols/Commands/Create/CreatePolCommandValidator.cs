using FluentValidation;

namespace Application.Features.Pols.Commands.Create;

public class CreatePolCommandValidator : AbstractValidator<CreatePolCommand>
{
    public CreatePolCommandValidator()
    {
        RuleFor(c => c.PolName).NotEmpty();
    }
}