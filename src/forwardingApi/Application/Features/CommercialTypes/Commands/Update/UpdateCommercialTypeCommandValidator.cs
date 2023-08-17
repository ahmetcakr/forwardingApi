using FluentValidation;

namespace Application.Features.CommercialTypes.Commands.Update;

public class UpdateCommercialTypeCommandValidator : AbstractValidator<UpdateCommercialTypeCommand>
{
    public UpdateCommercialTypeCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Name).NotEmpty();
    }
}