using FluentValidation;

namespace Application.Features.CustomerSectors.Commands.Delete;

public class DeleteCustomerSectorCommandValidator : AbstractValidator<DeleteCustomerSectorCommand>
{
    public DeleteCustomerSectorCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}