using FluentValidation;

namespace Application.Features.Routes.Commands.Create;

public class CreateRouteCommandValidator : AbstractValidator<CreateRouteCommand>
{
    public CreateRouteCommandValidator()
    {
        RuleFor(c => c.RouteName).NotEmpty();
        RuleFor(c => c.RouteCode).NotEmpty();
        RuleFor(c => c.RouteDescription).NotEmpty();
        RuleFor(c => c.RouteType).NotEmpty();
        RuleFor(c => c.RouteStatus).NotEmpty();
        RuleFor(c => c.RouteNote).NotEmpty();
    }
}