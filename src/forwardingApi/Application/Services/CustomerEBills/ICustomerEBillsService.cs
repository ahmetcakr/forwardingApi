using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.CustomerEBills;

public interface ICustomerEBillsService
{
    Task<CustomerEBill?> GetAsync(
        Expression<Func<CustomerEBill, bool>> predicate,
        Func<IQueryable<CustomerEBill>, IIncludableQueryable<CustomerEBill, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<CustomerEBill>?> GetListAsync(
        Expression<Func<CustomerEBill, bool>>? predicate = null,
        Func<IQueryable<CustomerEBill>, IOrderedQueryable<CustomerEBill>>? orderBy = null,
        Func<IQueryable<CustomerEBill>, IIncludableQueryable<CustomerEBill, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<CustomerEBill> AddAsync(CustomerEBill customerEBill);
    Task<CustomerEBill> UpdateAsync(CustomerEBill customerEBill);
    Task<CustomerEBill> DeleteAsync(CustomerEBill customerEBill, bool permanent = false);
}
