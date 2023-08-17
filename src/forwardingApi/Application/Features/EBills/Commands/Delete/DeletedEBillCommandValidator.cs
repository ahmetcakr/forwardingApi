using FluentValidation;

namespace Application.Features.EBills.Commands.Delete;

public class DeleteEBillCommandValidator : AbstractValidator<DeleteEBillCommand>
{
    public DeleteEBillCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}