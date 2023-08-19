using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.FreeDays;

public interface IFreeDaysService
{
    Task<FreeDay?> GetAsync(
        Expression<Func<FreeDay, bool>> predicate,
        Func<IQueryable<FreeDay>, IIncludableQueryable<FreeDay, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<FreeDay>?> GetListAsync(
        Expression<Func<FreeDay, bool>>? predicate = null,
        Func<IQueryable<FreeDay>, IOrderedQueryable<FreeDay>>? orderBy = null,
        Func<IQueryable<FreeDay>, IIncludableQueryable<FreeDay, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<FreeDay> AddAsync(FreeDay freeDay);
    Task<FreeDay> UpdateAsync(FreeDay freeDay);
    Task<FreeDay> DeleteAsync(FreeDay freeDay, bool permanent = false);
}
