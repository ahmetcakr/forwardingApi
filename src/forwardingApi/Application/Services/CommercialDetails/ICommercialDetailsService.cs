using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.CommercialDetails;

public interface ICommercialDetailsService
{
    Task<CommercialDetail?> GetAsync(
        Expression<Func<CommercialDetail, bool>> predicate,
        Func<IQueryable<CommercialDetail>, IIncludableQueryable<CommercialDetail, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<CommercialDetail>?> GetListAsync(
        Expression<Func<CommercialDetail, bool>>? predicate = null,
        Func<IQueryable<CommercialDetail>, IOrderedQueryable<CommercialDetail>>? orderBy = null,
        Func<IQueryable<CommercialDetail>, IIncludableQueryable<CommercialDetail, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<CommercialDetail> AddAsync(CommercialDetail commercialDetail);
    Task<CommercialDetail> UpdateAsync(CommercialDetail commercialDetail);
    Task<CommercialDetail> DeleteAsync(CommercialDetail commercialDetail, bool permanent = false);
}
