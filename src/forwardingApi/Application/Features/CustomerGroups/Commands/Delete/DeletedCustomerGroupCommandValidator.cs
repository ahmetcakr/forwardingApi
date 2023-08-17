using FluentValidation;

namespace Application.Features.CustomerGroups.Commands.Delete;

public class DeleteCustomerGroupCommandValidator : AbstractValidator<DeleteCustomerGroupCommand>
{
    public DeleteCustomerGroupCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}