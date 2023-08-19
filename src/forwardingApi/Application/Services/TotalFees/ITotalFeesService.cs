using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.TotalFees;

public interface ITotalFeesService
{
    Task<TotalFee?> GetAsync(
        Expression<Func<TotalFee, bool>> predicate,
        Func<IQueryable<TotalFee>, IIncludableQueryable<TotalFee, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<TotalFee>?> GetListAsync(
        Expression<Func<TotalFee, bool>>? predicate = null,
        Func<IQueryable<TotalFee>, IOrderedQueryable<TotalFee>>? orderBy = null,
        Func<IQueryable<TotalFee>, IIncludableQueryable<TotalFee, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<TotalFee> AddAsync(TotalFee totalFee);
    Task<TotalFee> UpdateAsync(TotalFee totalFee);
    Task<TotalFee> DeleteAsync(TotalFee totalFee, bool permanent = false);
}
