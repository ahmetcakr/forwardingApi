using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Ships;

public interface IShipsService
{
    Task<Ship?> GetAsync(
        Expression<Func<Ship, bool>> predicate,
        Func<IQueryable<Ship>, IIncludableQueryable<Ship, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<Ship>?> GetListAsync(
        Expression<Func<Ship, bool>>? predicate = null,
        Func<IQueryable<Ship>, IOrderedQueryable<Ship>>? orderBy = null,
        Func<IQueryable<Ship>, IIncludableQueryable<Ship, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<Ship> AddAsync(Ship ship);
    Task<Ship> UpdateAsync(Ship ship);
    Task<Ship> DeleteAsync(Ship ship, bool permanent = false);
}
