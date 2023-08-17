using FluentValidation;

namespace Application.Features.Sectors.Commands.Update;

public class UpdateSectorCommandValidator : AbstractValidator<UpdateSectorCommand>
{
    public UpdateSectorCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Name).NotEmpty();
    }
}