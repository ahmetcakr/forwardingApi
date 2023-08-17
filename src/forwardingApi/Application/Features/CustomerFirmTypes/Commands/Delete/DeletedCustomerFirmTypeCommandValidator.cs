using FluentValidation;

namespace Application.Features.CustomerFirmTypes.Commands.Delete;

public class DeleteCustomerFirmTypeCommandValidator : AbstractValidator<DeleteCustomerFirmTypeCommand>
{
    public DeleteCustomerFirmTypeCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}