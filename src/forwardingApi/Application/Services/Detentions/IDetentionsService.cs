using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Detentions;

public interface IDetentionsService
{
    Task<Detention?> GetAsync(
        Expression<Func<Detention, bool>> predicate,
        Func<IQueryable<Detention>, IIncludableQueryable<Detention, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<Detention>?> GetListAsync(
        Expression<Func<Detention, bool>>? predicate = null,
        Func<IQueryable<Detention>, IOrderedQueryable<Detention>>? orderBy = null,
        Func<IQueryable<Detention>, IIncludableQueryable<Detention, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<Detention> AddAsync(Detention detention);
    Task<Detention> UpdateAsync(Detention detention);
    Task<Detention> DeleteAsync(Detention detention, bool permanent = false);
}
