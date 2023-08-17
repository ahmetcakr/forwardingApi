using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.EBills;

public interface IEBillsService
{
    Task<EBill?> GetAsync(
        Expression<Func<EBill, bool>> predicate,
        Func<IQueryable<EBill>, IIncludableQueryable<EBill, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<EBill>?> GetListAsync(
        Expression<Func<EBill, bool>>? predicate = null,
        Func<IQueryable<EBill>, IOrderedQueryable<EBill>>? orderBy = null,
        Func<IQueryable<EBill>, IIncludableQueryable<EBill, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<EBill> AddAsync(EBill eBill);
    Task<EBill> UpdateAsync(EBill eBill);
    Task<EBill> DeleteAsync(EBill eBill, bool permanent = false);
}
