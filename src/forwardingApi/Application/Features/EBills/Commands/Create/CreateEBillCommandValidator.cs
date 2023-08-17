using FluentValidation;

namespace Application.Features.EBills.Commands.Create;

public class CreateEBillCommandValidator : AbstractValidator<CreateEBillCommand>
{
    public CreateEBillCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.Description).NotEmpty();
        RuleFor(c => c.Phone).NotEmpty();
        RuleFor(c => c.Address).NotEmpty();
        RuleFor(c => c.Mail).NotEmpty();
    }
}