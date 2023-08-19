using FluentValidation;

namespace Application.Features.Routes.Commands.Delete;

public class DeleteRouteCommandValidator : AbstractValidator<DeleteRouteCommand>
{
    public DeleteRouteCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}