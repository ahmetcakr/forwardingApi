using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Pols;

public interface IPolsService
{
    Task<Pol?> GetAsync(
        Expression<Func<Pol, bool>> predicate,
        Func<IQueryable<Pol>, IIncludableQueryable<Pol, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<Pol>?> GetListAsync(
        Expression<Func<Pol, bool>>? predicate = null,
        Func<IQueryable<Pol>, IOrderedQueryable<Pol>>? orderBy = null,
        Func<IQueryable<Pol>, IIncludableQueryable<Pol, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<Pol> AddAsync(Pol pol);
    Task<Pol> UpdateAsync(Pol pol);
    Task<Pol> DeleteAsync(Pol pol, bool permanent = false);
}
