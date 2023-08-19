using FluentValidation;

namespace Application.Features.Voyages.Commands.Create;

public class CreateVoyageCommandValidator : AbstractValidator<CreateVoyageCommand>
{
    public CreateVoyageCommandValidator()
    {
        RuleFor(c => c.VoyageName).NotEmpty();
    }
}