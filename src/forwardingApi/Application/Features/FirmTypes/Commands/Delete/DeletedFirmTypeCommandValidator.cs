using FluentValidation;

namespace Application.Features.FirmTypes.Commands.Delete;

public class DeleteFirmTypeCommandValidator : AbstractValidator<DeleteFirmTypeCommand>
{
    public DeleteFirmTypeCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}