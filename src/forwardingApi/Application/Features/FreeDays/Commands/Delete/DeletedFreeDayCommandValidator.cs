using FluentValidation;

namespace Application.Features.FreeDays.Commands.Delete;

public class DeleteFreeDayCommandValidator : AbstractValidator<DeleteFreeDayCommand>
{
    public DeleteFreeDayCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}