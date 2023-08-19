using FluentValidation;

namespace Application.Features.Consignes.Commands.Create;

public class CreateConsigneCommandValidator : AbstractValidator<CreateConsigneCommand>
{
    public CreateConsigneCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.Description).NotEmpty();
    }
}