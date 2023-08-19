using Application.Features.Routes.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.Routes.Rules;

public class RouteBusinessRules : BaseBusinessRules
{
    private readonly IRouteRepository _routeRepository;

    public RouteBusinessRules(IRouteRepository routeRepository)
    {
        _routeRepository = routeRepository;
    }

    public Task RouteShouldExistWhenSelected(Route? route)
    {
        if (route == null)
            throw new BusinessException(RoutesBusinessMessages.RouteNotExists);
        return Task.CompletedTask;
    }

    public async Task RouteIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        Route? route = await _routeRepository.GetAsync(
            predicate: r => r.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await RouteShouldExistWhenSelected(route);
    }
}