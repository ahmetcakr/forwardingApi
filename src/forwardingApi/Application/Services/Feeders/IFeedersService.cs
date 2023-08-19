using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Feeders;

public interface IFeedersService
{
    Task<Feeder?> GetAsync(
        Expression<Func<Feeder, bool>> predicate,
        Func<IQueryable<Feeder>, IIncludableQueryable<Feeder, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<Feeder>?> GetListAsync(
        Expression<Func<Feeder, bool>>? predicate = null,
        Func<IQueryable<Feeder>, IOrderedQueryable<Feeder>>? orderBy = null,
        Func<IQueryable<Feeder>, IIncludableQueryable<Feeder, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<Feeder> AddAsync(Feeder feeder);
    Task<Feeder> UpdateAsync(Feeder feeder);
    Task<Feeder> DeleteAsync(Feeder feeder, bool permanent = false);
}
