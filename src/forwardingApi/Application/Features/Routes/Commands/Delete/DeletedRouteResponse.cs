using Core.Application.Responses;

namespace Application.Features.Routes.Commands.Delete;

public class DeletedRouteResponse : IResponse
{
    public int Id { get; set; }
}