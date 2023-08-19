using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Demurrages;

public interface IDemurragesService
{
    Task<Demurrage?> GetAsync(
        Expression<Func<Demurrage, bool>> predicate,
        Func<IQueryable<Demurrage>, IIncludableQueryable<Demurrage, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<Demurrage>?> GetListAsync(
        Expression<Func<Demurrage, bool>>? predicate = null,
        Func<IQueryable<Demurrage>, IOrderedQueryable<Demurrage>>? orderBy = null,
        Func<IQueryable<Demurrage>, IIncludableQueryable<Demurrage, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<Demurrage> AddAsync(Demurrage demurrage);
    Task<Demurrage> UpdateAsync(Demurrage demurrage);
    Task<Demurrage> DeleteAsync(Demurrage demurrage, bool permanent = false);
}
