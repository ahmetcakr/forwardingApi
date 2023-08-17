using FluentValidation;

namespace Application.Features.CustomerEBills.Commands.Update;

public class UpdateCustomerEBillCommandValidator : AbstractValidator<UpdateCustomerEBillCommand>
{
    public UpdateCustomerEBillCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.CustomerId).NotEmpty();
        RuleFor(c => c.EBillId).NotEmpty();
    }
}