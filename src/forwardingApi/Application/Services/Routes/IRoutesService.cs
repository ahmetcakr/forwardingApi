using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Routes;

public interface IRoutesService
{
    Task<Route?> GetAsync(
        Expression<Func<Route, bool>> predicate,
        Func<IQueryable<Route>, IIncludableQueryable<Route, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<Route>?> GetListAsync(
        Expression<Func<Route, bool>>? predicate = null,
        Func<IQueryable<Route>, IOrderedQueryable<Route>>? orderBy = null,
        Func<IQueryable<Route>, IIncludableQueryable<Route, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<Route> AddAsync(Route route);
    Task<Route> UpdateAsync(Route route);
    Task<Route> DeleteAsync(Route route, bool permanent = false);
}
