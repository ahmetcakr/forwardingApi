using FluentValidation;

namespace Application.Features.TotalFees.Commands.Delete;

public class DeleteTotalFeeCommandValidator : AbstractValidator<DeleteTotalFeeCommand>
{
    public DeleteTotalFeeCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}