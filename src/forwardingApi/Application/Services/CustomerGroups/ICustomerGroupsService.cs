using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.CustomerGroups;

public interface ICustomerGroupsService
{
    Task<CustomerGroup?> GetAsync(
        Expression<Func<CustomerGroup, bool>> predicate,
        Func<IQueryable<CustomerGroup>, IIncludableQueryable<CustomerGroup, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<CustomerGroup>?> GetListAsync(
        Expression<Func<CustomerGroup, bool>>? predicate = null,
        Func<IQueryable<CustomerGroup>, IOrderedQueryable<CustomerGroup>>? orderBy = null,
        Func<IQueryable<CustomerGroup>, IIncludableQueryable<CustomerGroup, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<CustomerGroup> AddAsync(CustomerGroup customerGroup);
    Task<CustomerGroup> UpdateAsync(CustomerGroup customerGroup);
    Task<CustomerGroup> DeleteAsync(CustomerGroup customerGroup, bool permanent = false);
}
