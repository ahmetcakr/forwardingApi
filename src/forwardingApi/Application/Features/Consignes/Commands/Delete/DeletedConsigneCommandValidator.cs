using FluentValidation;

namespace Application.Features.Consignes.Commands.Delete;

public class DeleteConsigneCommandValidator : AbstractValidator<DeleteConsigneCommand>
{
    public DeleteConsigneCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}