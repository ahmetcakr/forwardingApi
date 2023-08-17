using FluentValidation;

namespace Application.Features.EBills.Commands.Update;

public class UpdateEBillCommandValidator : AbstractValidator<UpdateEBillCommand>
{
    public UpdateEBillCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.Description).NotEmpty();
        RuleFor(c => c.Phone).NotEmpty();
        RuleFor(c => c.Address).NotEmpty();
        RuleFor(c => c.Mail).NotEmpty();
    }
}