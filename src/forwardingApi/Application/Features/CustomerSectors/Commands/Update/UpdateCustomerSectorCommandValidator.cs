using FluentValidation;

namespace Application.Features.CustomerSectors.Commands.Update;

public class UpdateCustomerSectorCommandValidator : AbstractValidator<UpdateCustomerSectorCommand>
{
    public UpdateCustomerSectorCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.CustomerId).NotEmpty();
        RuleFor(c => c.SectorId).NotEmpty();
    }
}