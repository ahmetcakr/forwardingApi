using FluentValidation;

namespace Application.Features.Feeders.Commands.Update;

public class UpdateFeederCommandValidator : AbstractValidator<UpdateFeederCommand>
{
    public UpdateFeederCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.FeederName).NotEmpty();
    }
}