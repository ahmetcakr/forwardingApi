using FluentValidation;

namespace Application.Features.CustomerFirmTypes.Commands.Create;

public class CreateCustomerFirmTypeCommandValidator : AbstractValidator<CreateCustomerFirmTypeCommand>
{
    public CreateCustomerFirmTypeCommandValidator()
    {
        RuleFor(c => c.CustomerId).NotEmpty();
        RuleFor(c => c.FirmTypeId).NotEmpty();
    }
}