using Core.Application.Responses;

namespace Application.Features.Routes.Commands.Update;

public class UpdatedRouteResponse : IResponse
{
    public int Id { get; set; }
    public string? RouteName { get; set; }
    public string? RouteCode { get; set; }
    public string? RouteDescription { get; set; }
    public string? RouteType { get; set; }
    public string? RouteStatus { get; set; }
    public string? RouteNote { get; set; }
}