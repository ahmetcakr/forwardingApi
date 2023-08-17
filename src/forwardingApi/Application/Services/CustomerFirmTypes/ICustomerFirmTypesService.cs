using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.CustomerFirmTypes;

public interface ICustomerFirmTypesService
{
    Task<CustomerFirmType?> GetAsync(
        Expression<Func<CustomerFirmType, bool>> predicate,
        Func<IQueryable<CustomerFirmType>, IIncludableQueryable<CustomerFirmType, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<CustomerFirmType>?> GetListAsync(
        Expression<Func<CustomerFirmType, bool>>? predicate = null,
        Func<IQueryable<CustomerFirmType>, IOrderedQueryable<CustomerFirmType>>? orderBy = null,
        Func<IQueryable<CustomerFirmType>, IIncludableQueryable<CustomerFirmType, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<CustomerFirmType> AddAsync(CustomerFirmType customerFirmType);
    Task<CustomerFirmType> UpdateAsync(CustomerFirmType customerFirmType);
    Task<CustomerFirmType> DeleteAsync(CustomerFirmType customerFirmType, bool permanent = false);
}
