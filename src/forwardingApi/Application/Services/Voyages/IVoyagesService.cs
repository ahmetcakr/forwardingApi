using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Voyages;

public interface IVoyagesService
{
    Task<Voyage?> GetAsync(
        Expression<Func<Voyage, bool>> predicate,
        Func<IQueryable<Voyage>, IIncludableQueryable<Voyage, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<Voyage>?> GetListAsync(
        Expression<Func<Voyage, bool>>? predicate = null,
        Func<IQueryable<Voyage>, IOrderedQueryable<Voyage>>? orderBy = null,
        Func<IQueryable<Voyage>, IIncludableQueryable<Voyage, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<Voyage> AddAsync(Voyage voyage);
    Task<Voyage> UpdateAsync(Voyage voyage);
    Task<Voyage> DeleteAsync(Voyage voyage, bool permanent = false);
}
