using FluentValidation;

namespace Application.Features.TotalFees.Commands.Update;

public class UpdateTotalFeeCommandValidator : AbstractValidator<UpdateTotalFeeCommand>
{
    public UpdateTotalFeeCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Fee).NotEmpty();
        RuleFor(c => c.Vat).NotEmpty();
        RuleFor(c => c.Total).NotEmpty();
    }
}