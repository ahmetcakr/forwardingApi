using FluentValidation;

namespace Application.Features.Consignes.Commands.Update;

public class UpdateConsigneCommandValidator : AbstractValidator<UpdateConsigneCommand>
{
    public UpdateConsigneCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.Description).NotEmpty();
    }
}