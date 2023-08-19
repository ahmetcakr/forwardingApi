using FluentValidation;

namespace Application.Features.Pols.Commands.Update;

public class UpdatePolCommandValidator : AbstractValidator<UpdatePolCommand>
{
    public UpdatePolCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.PolName).NotEmpty();
    }
}