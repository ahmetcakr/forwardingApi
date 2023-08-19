using FluentValidation;

namespace Application.Features.Voyages.Commands.Update;

public class UpdateVoyageCommandValidator : AbstractValidator<UpdateVoyageCommand>
{
    public UpdateVoyageCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.VoyageName).NotEmpty();
    }
}