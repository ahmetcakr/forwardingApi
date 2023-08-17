using FluentValidation;

namespace Application.Features.Sectors.Commands.Create;

public class CreateSectorCommandValidator : AbstractValidator<CreateSectorCommand>
{
    public CreateSectorCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty();
    }
}