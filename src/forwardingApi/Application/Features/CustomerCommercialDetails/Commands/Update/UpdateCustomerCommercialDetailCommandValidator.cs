using FluentValidation;

namespace Application.Features.CustomerCommercialDetails.Commands.Update;

public class UpdateCustomerCommercialDetailCommandValidator : AbstractValidator<UpdateCustomerCommercialDetailCommand>
{
    public UpdateCustomerCommercialDetailCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.CustomerId).NotEmpty();
        RuleFor(c => c.CommercialDetailId).NotEmpty();
    }
}