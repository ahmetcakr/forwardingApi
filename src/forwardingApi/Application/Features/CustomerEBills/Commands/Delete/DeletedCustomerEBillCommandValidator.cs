using FluentValidation;

namespace Application.Features.CustomerEBills.Commands.Delete;

public class DeleteCustomerEBillCommandValidator : AbstractValidator<DeleteCustomerEBillCommand>
{
    public DeleteCustomerEBillCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}