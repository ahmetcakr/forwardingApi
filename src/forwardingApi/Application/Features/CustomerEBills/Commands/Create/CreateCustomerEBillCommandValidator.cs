using FluentValidation;

namespace Application.Features.CustomerEBills.Commands.Create;

public class CreateCustomerEBillCommandValidator : AbstractValidator<CreateCustomerEBillCommand>
{
    public CreateCustomerEBillCommandValidator()
    {
        RuleFor(c => c.CustomerId).NotEmpty();
        RuleFor(c => c.EBillId).NotEmpty();
    }
}