using FluentValidation;

namespace Application.Features.Detentions.Commands.Update;

public class UpdateDetentionCommandValidator : AbstractValidator<UpdateDetentionCommand>
{
    public UpdateDetentionCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Day).NotEmpty();
        RuleFor(c => c.Fee).NotEmpty();
    }
}