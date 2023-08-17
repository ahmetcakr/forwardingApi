using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.CustomerSectors;

public interface ICustomerSectorsService
{
    Task<CustomerSector?> GetAsync(
        Expression<Func<CustomerSector, bool>> predicate,
        Func<IQueryable<CustomerSector>, IIncludableQueryable<CustomerSector, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<CustomerSector>?> GetListAsync(
        Expression<Func<CustomerSector, bool>>? predicate = null,
        Func<IQueryable<CustomerSector>, IOrderedQueryable<CustomerSector>>? orderBy = null,
        Func<IQueryable<CustomerSector>, IIncludableQueryable<CustomerSector, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<CustomerSector> AddAsync(CustomerSector customerSector);
    Task<CustomerSector> UpdateAsync(CustomerSector customerSector);
    Task<CustomerSector> DeleteAsync(CustomerSector customerSector, bool permanent = false);
}
