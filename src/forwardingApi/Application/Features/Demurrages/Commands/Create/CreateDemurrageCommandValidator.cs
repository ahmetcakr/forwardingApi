using FluentValidation;

namespace Application.Features.Demurrages.Commands.Create;

public class CreateDemurrageCommandValidator : AbstractValidator<CreateDemurrageCommand>
{
    public CreateDemurrageCommandValidator()
    {
        RuleFor(c => c.StartDate).NotEmpty();
        RuleFor(c => c.Day).NotEmpty();
        RuleFor(c => c.Fee).NotEmpty();
    }
}