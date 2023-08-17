using FluentValidation;

namespace Application.Features.CustomerCommercialDetails.Commands.Create;

public class CreateCustomerCommercialDetailCommandValidator : AbstractValidator<CreateCustomerCommercialDetailCommand>
{
    public CreateCustomerCommercialDetailCommandValidator()
    {
        RuleFor(c => c.CustomerId).NotEmpty();
        RuleFor(c => c.CommercialDetailId).NotEmpty();
    }
}