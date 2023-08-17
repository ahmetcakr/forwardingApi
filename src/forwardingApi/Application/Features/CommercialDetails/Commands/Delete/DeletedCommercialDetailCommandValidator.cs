using FluentValidation;

namespace Application.Features.CommercialDetails.Commands.Delete;

public class DeleteCommercialDetailCommandValidator : AbstractValidator<DeleteCommercialDetailCommand>
{
    public DeleteCommercialDetailCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}