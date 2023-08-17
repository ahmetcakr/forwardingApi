using FluentValidation;

namespace Application.Features.CommercialTypes.Commands.Delete;

public class DeleteCommercialTypeCommandValidator : AbstractValidator<DeleteCommercialTypeCommand>
{
    public DeleteCommercialTypeCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}