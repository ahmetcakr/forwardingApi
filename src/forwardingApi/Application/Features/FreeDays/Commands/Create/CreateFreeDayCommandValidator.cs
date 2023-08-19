using FluentValidation;

namespace Application.Features.FreeDays.Commands.Create;

public class CreateFreeDayCommandValidator : AbstractValidator<CreateFreeDayCommand>
{
    public CreateFreeDayCommandValidator()
    {
        RuleFor(c => c.StartDate).NotEmpty();
        RuleFor(c => c.EndDate).NotEmpty();
        RuleFor(c => c.Day).NotEmpty();
        RuleFor(c => c.Fee).NotEmpty();
        RuleFor(c => c.Total).NotEmpty();
        RuleFor(c => c.TotalFee).NotEmpty();
    }
}