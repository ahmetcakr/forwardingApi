using Application.Features.Routes.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Routes;

public class RoutesManager : IRoutesService
{
    private readonly IRouteRepository _routeRepository;
    private readonly RouteBusinessRules _routeBusinessRules;

    public RoutesManager(IRouteRepository routeRepository, RouteBusinessRules routeBusinessRules)
    {
        _routeRepository = routeRepository;
        _routeBusinessRules = routeBusinessRules;
    }

    public async Task<Route?> GetAsync(
        Expression<Func<Route, bool>> predicate,
        Func<IQueryable<Route>, IIncludableQueryable<Route, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        Route? route = await _routeRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return route;
    }

    public async Task<IPaginate<Route>?> GetListAsync(
        Expression<Func<Route, bool>>? predicate = null,
        Func<IQueryable<Route>, IOrderedQueryable<Route>>? orderBy = null,
        Func<IQueryable<Route>, IIncludableQueryable<Route, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<Route> routeList = await _routeRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return routeList;
    }

    public async Task<Route> AddAsync(Route route)
    {
        Route addedRoute = await _routeRepository.AddAsync(route);

        return addedRoute;
    }

    public async Task<Route> UpdateAsync(Route route)
    {
        Route updatedRoute = await _routeRepository.UpdateAsync(route);

        return updatedRoute;
    }

    public async Task<Route> DeleteAsync(Route route, bool permanent = false)
    {
        Route deletedRoute = await _routeRepository.DeleteAsync(route);

        return deletedRoute;
    }
}
