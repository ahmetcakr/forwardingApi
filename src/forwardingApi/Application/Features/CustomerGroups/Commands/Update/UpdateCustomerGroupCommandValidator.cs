using FluentValidation;

namespace Application.Features.CustomerGroups.Commands.Update;

public class UpdateCustomerGroupCommandValidator : AbstractValidator<UpdateCustomerGroupCommand>
{
    public UpdateCustomerGroupCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.CustomerId).NotEmpty();
        RuleFor(c => c.GroupId).NotEmpty();
    }
}