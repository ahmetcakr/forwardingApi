using FluentValidation;

namespace Application.Features.CustomerCommercialTypes.Commands.Create;

public class CreateCustomerCommercialTypeCommandValidator : AbstractValidator<CreateCustomerCommercialTypeCommand>
{
    public CreateCustomerCommercialTypeCommandValidator()
    {
        RuleFor(c => c.CustomerId).NotEmpty();
        RuleFor(c => c.CommercialTypeId).NotEmpty();
    }
}