using Core.Persistence.Repositories;

namespace Domain.Entities;

public class Route : Entity<int>
{
    // Route class
    public string? RouteName { get; set; }
    public string? RouteCode { get; set; }
    public string? RouteDescription { get; set; }
    public string? RouteType { get; set; }
    public string? RouteStatus { get; set; }
    public string? RouteNote { get; set; }

}