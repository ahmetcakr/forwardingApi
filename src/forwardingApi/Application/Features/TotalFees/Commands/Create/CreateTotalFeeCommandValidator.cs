using FluentValidation;

namespace Application.Features.TotalFees.Commands.Create;

public class CreateTotalFeeCommandValidator : AbstractValidator<CreateTotalFeeCommand>
{
    public CreateTotalFeeCommandValidator()
    {
        RuleFor(c => c.Fee).NotEmpty();
        RuleFor(c => c.Vat).NotEmpty();
        RuleFor(c => c.Total).NotEmpty();
    }
}