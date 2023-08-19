using FluentValidation;

namespace Application.Features.Routes.Commands.Update;

public class UpdateRouteCommandValidator : AbstractValidator<UpdateRouteCommand>
{
    public UpdateRouteCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.RouteName).NotEmpty();
        RuleFor(c => c.RouteCode).NotEmpty();
        RuleFor(c => c.RouteDescription).NotEmpty();
        RuleFor(c => c.RouteType).NotEmpty();
        RuleFor(c => c.RouteStatus).NotEmpty();
        RuleFor(c => c.RouteNote).NotEmpty();
    }
}