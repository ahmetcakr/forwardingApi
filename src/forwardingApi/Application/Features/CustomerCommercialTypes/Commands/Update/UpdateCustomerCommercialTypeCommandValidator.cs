using FluentValidation;

namespace Application.Features.CustomerCommercialTypes.Commands.Update;

public class UpdateCustomerCommercialTypeCommandValidator : AbstractValidator<UpdateCustomerCommercialTypeCommand>
{
    public UpdateCustomerCommercialTypeCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.CustomerId).NotEmpty();
        RuleFor(c => c.CommercialTypeId).NotEmpty();
    }
}