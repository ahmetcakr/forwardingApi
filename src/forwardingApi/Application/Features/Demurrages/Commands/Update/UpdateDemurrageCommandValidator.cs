using FluentValidation;

namespace Application.Features.Demurrages.Commands.Update;

public class UpdateDemurrageCommandValidator : AbstractValidator<UpdateDemurrageCommand>
{
    public UpdateDemurrageCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.StartDate).NotEmpty();
        RuleFor(c => c.Day).NotEmpty();
        RuleFor(c => c.Fee).NotEmpty();
    }
}