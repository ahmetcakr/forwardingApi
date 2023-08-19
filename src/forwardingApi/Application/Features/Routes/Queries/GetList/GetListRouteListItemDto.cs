using Core.Application.Dtos;

namespace Application.Features.Routes.Queries.GetList;

public class GetListRouteListItemDto : IDto
{
    public int Id { get; set; }
    public string? RouteName { get; set; }
    public string? RouteCode { get; set; }
    public string? RouteDescription { get; set; }
    public string? RouteType { get; set; }
    public string? RouteStatus { get; set; }
    public string? RouteNote { get; set; }
}