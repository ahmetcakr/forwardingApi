using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.CustomerCommercialDetails;

public interface ICustomerCommercialDetailsService
{
    Task<CustomerCommercialDetail?> GetAsync(
        Expression<Func<CustomerCommercialDetail, bool>> predicate,
        Func<IQueryable<CustomerCommercialDetail>, IIncludableQueryable<CustomerCommercialDetail, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<CustomerCommercialDetail>?> GetListAsync(
        Expression<Func<CustomerCommercialDetail, bool>>? predicate = null,
        Func<IQueryable<CustomerCommercialDetail>, IOrderedQueryable<CustomerCommercialDetail>>? orderBy = null,
        Func<IQueryable<CustomerCommercialDetail>, IIncludableQueryable<CustomerCommercialDetail, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<CustomerCommercialDetail> AddAsync(CustomerCommercialDetail customerCommercialDetail);
    Task<CustomerCommercialDetail> UpdateAsync(CustomerCommercialDetail customerCommercialDetail);
    Task<CustomerCommercialDetail> DeleteAsync(CustomerCommercialDetail customerCommercialDetail, bool permanent = false);
}
