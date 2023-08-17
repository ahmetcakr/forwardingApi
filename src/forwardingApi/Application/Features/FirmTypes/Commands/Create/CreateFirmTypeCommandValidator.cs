using FluentValidation;

namespace Application.Features.FirmTypes.Commands.Create;

public class CreateFirmTypeCommandValidator : AbstractValidator<CreateFirmTypeCommand>
{
    public CreateFirmTypeCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty();
    }
}