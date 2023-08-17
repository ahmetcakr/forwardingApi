using FluentValidation;

namespace Application.Features.CustomerGroups.Commands.Create;

public class CreateCustomerGroupCommandValidator : AbstractValidator<CreateCustomerGroupCommand>
{
    public CreateCustomerGroupCommandValidator()
    {
        RuleFor(c => c.CustomerId).NotEmpty();
        RuleFor(c => c.GroupId).NotEmpty();
    }
}