using FluentValidation;

namespace Application.Features.CustomerSectors.Commands.Create;

public class CreateCustomerSectorCommandValidator : AbstractValidator<CreateCustomerSectorCommand>
{
    public CreateCustomerSectorCommandValidator()
    {
        RuleFor(c => c.CustomerId).NotEmpty();
        RuleFor(c => c.SectorId).NotEmpty();
    }
}