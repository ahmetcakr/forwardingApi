using FluentValidation;

namespace Application.Features.CustomerCommercialDetails.Commands.Delete;

public class DeleteCustomerCommercialDetailCommandValidator : AbstractValidator<DeleteCustomerCommercialDetailCommand>
{
    public DeleteCustomerCommercialDetailCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}