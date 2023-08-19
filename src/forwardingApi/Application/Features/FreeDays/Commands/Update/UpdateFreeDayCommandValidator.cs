using FluentValidation;

namespace Application.Features.FreeDays.Commands.Update;

public class UpdateFreeDayCommandValidator : AbstractValidator<UpdateFreeDayCommand>
{
    public UpdateFreeDayCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.StartDate).NotEmpty();
        RuleFor(c => c.EndDate).NotEmpty();
        RuleFor(c => c.Day).NotEmpty();
        RuleFor(c => c.Fee).NotEmpty();
        RuleFor(c => c.Total).NotEmpty();
        RuleFor(c => c.TotalFee).NotEmpty();
    }
}