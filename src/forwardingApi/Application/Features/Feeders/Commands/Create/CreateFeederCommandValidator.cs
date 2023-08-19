using FluentValidation;

namespace Application.Features.Feeders.Commands.Create;

public class CreateFeederCommandValidator : AbstractValidator<CreateFeederCommand>
{
    public CreateFeederCommandValidator()
    {
        RuleFor(c => c.FeederName).NotEmpty();
    }
}