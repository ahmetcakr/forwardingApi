using FluentValidation;

namespace Application.Features.CustomerCommercialTypes.Commands.Delete;

public class DeleteCustomerCommercialTypeCommandValidator : AbstractValidator<DeleteCustomerCommercialTypeCommand>
{
    public DeleteCustomerCommercialTypeCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}