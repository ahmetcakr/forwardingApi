using Core.Application.Responses;

namespace Application.Features.Routes.Commands.Create;

public class CreatedRouteResponse : IResponse
{
    public int Id { get; set; }
    public string? RouteName { get; set; }
    public string? RouteCode { get; set; }
    public string? RouteDescription { get; set; }
    public string? RouteType { get; set; }
    public string? RouteStatus { get; set; }
    public string? RouteNote { get; set; }
}