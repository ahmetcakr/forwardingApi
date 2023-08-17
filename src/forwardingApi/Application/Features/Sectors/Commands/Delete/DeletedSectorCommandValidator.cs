using FluentValidation;

namespace Application.Features.Sectors.Commands.Delete;

public class DeleteSectorCommandValidator : AbstractValidator<DeleteSectorCommand>
{
    public DeleteSectorCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}