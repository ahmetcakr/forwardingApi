using FluentValidation;

namespace Application.Features.CommercialTypes.Commands.Create;

public class CreateCommercialTypeCommandValidator : AbstractValidator<CreateCommercialTypeCommand>
{
    public CreateCommercialTypeCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty();
    }
}