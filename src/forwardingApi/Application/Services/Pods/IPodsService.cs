using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Pods;

public interface IPodsService
{
    Task<Pod?> GetAsync(
        Expression<Func<Pod, bool>> predicate,
        Func<IQueryable<Pod>, IIncludableQueryable<Pod, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<Pod>?> GetListAsync(
        Expression<Func<Pod, bool>>? predicate = null,
        Func<IQueryable<Pod>, IOrderedQueryable<Pod>>? orderBy = null,
        Func<IQueryable<Pod>, IIncludableQueryable<Pod, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<Pod> AddAsync(Pod pod);
    Task<Pod> UpdateAsync(Pod pod);
    Task<Pod> DeleteAsync(Pod pod, bool permanent = false);
}
