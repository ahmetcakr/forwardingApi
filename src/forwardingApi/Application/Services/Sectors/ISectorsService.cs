using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Sectors;

public interface ISectorsService
{
    Task<Sector?> GetAsync(
        Expression<Func<Sector, bool>> predicate,
        Func<IQueryable<Sector>, IIncludableQueryable<Sector, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<Sector>?> GetListAsync(
        Expression<Func<Sector, bool>>? predicate = null,
        Func<IQueryable<Sector>, IOrderedQueryable<Sector>>? orderBy = null,
        Func<IQueryable<Sector>, IIncludableQueryable<Sector, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<Sector> AddAsync(Sector sector);
    Task<Sector> UpdateAsync(Sector sector);
    Task<Sector> DeleteAsync(Sector sector, bool permanent = false);
}
