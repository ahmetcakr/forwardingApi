using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Consignes;

public interface IConsignesService
{
    Task<Consigne?> GetAsync(
        Expression<Func<Consigne, bool>> predicate,
        Func<IQueryable<Consigne>, IIncludableQueryable<Consigne, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<Consigne>?> GetListAsync(
        Expression<Func<Consigne, bool>>? predicate = null,
        Func<IQueryable<Consigne>, IOrderedQueryable<Consigne>>? orderBy = null,
        Func<IQueryable<Consigne>, IIncludableQueryable<Consigne, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<Consigne> AddAsync(Consigne consigne);
    Task<Consigne> UpdateAsync(Consigne consigne);
    Task<Consigne> DeleteAsync(Consigne consigne, bool permanent = false);
}
