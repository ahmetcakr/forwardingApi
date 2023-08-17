using FluentValidation;

namespace Application.Features.CustomerFirmTypes.Commands.Update;

public class UpdateCustomerFirmTypeCommandValidator : AbstractValidator<UpdateCustomerFirmTypeCommand>
{
    public UpdateCustomerFirmTypeCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.CustomerId).NotEmpty();
        RuleFor(c => c.FirmTypeId).NotEmpty();
    }
}