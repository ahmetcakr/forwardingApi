using FluentValidation;

namespace Application.Features.FirmTypes.Commands.Update;

public class UpdateFirmTypeCommandValidator : AbstractValidator<UpdateFirmTypeCommand>
{
    public UpdateFirmTypeCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Name).NotEmpty();
    }
}